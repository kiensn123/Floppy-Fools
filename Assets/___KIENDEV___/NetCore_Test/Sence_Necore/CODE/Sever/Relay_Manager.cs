using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport.Relay;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using UnityEngine;
using UnityEngine.UI;

public class Relay_Manager : MonoBehaviour
{

    [SerializeField] private Text joinCodeText;
    [SerializeField] private TMP_InputField joincodeinput;

    [SerializeField] private Button Start_Host;
    [SerializeField] private Button Join_Host;
    

    private async void Start()
    {
        Start_Game(); // Gọi phương thức để thiết lập sự kiện cho các nút bấm
        await UnityServices.InitializeAsync(); // Khởi tạo Unity Services (dùng cho Relay, Authentication, ...)
        await AuthenticationService.Instance.SignInAnonymouslyAsync(); // Đăng nhập ẩn danh vào Unity Authentication
    }

    public void Start_Game()
    {
        Start_Host.onClick.AddListener(StartRelay); // Khi bấm nút Start_Host, gọi phương thức StartRelay
        Join_Host.onClick.AddListener(Join_Relay); // Khi bấm nút Join_Host, gọi phương thức Join_Relay
    }

    public async void StartRelay()
    {
        string joincode = await StartHostWithRelay(); // Tạo host với Relay và nhận mã tham gia
        joinCodeText.text = joincode; // Hiển thị mã tham gia lên UI
    }

    public async void Join_Relay()
    {
        string code = joincodeinput.text; // Lấy mã tham gia từ input
        bool trangthai = await StartClientWithRelay(code); // Thử tham gia vào host bằng mã tham gia
        Debug.Log(trangthai); // In trạng thái kết nối thành công (true) hoặc thất bại (false)
    }

    private async Task<string> StartHostWithRelay(int max = 3)
    {
        // Tạo một phiên kết nối mới với tối đa "max" người chơi
        Allocation allocation = await RelayService.Instance.CreateAllocationAsync(max);

        // Lấy UnityTransport từ NetworkManager và thiết lập server Relay
        NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(new RelayServerData(allocation, "dtls"));

        // Lấy mã tham gia để gửi cho người chơi khác
        string joincode = await RelayService.Instance.GetJoinCodeAsync(allocation.AllocationId);

        // Bắt đầu host, nếu thành công thì trả về mã tham gia, nếu không thì trả về null
        return NetworkManager.Singleton.StartHost() ? joincode : null;
    }

    private async Task<bool> StartClientWithRelay(string joincode)
    {
        // Tham gia vào phiên kết nối bằng mã tham gia từ host
        JoinAllocation joinAllocation = await RelayService.Instance.JoinAllocationAsync(joincode);

        // Thiết lập dữ liệu máy chủ Relay vào UnityTransport
        NetworkManager.Singleton.GetComponent<UnityTransport>().SetRelayServerData(new RelayServerData(joinAllocation, "dtls"));

        // Kiểm tra nếu mã tham gia không rỗng và bắt đầu client
        return !string.IsNullOrEmpty(joincode) && NetworkManager.Singleton.StartClient();
    }


   
}
