using UnityEngine;

public class ScreenshotToFile : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) // Nhấn P để chụp
        {
            string fileName = Application.dataPath + "/Screenshot_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
            ScreenCapture.CaptureScreenshot(fileName);
            Debug.Log("Đã lưu ảnh: " + fileName);
        }
    }
}
