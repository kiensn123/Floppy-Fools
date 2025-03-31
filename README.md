# Floppy-Fools
=================
đây là dự án trò chơi vui vẻ về chủ đề nhân vật , game kết hợp với bạn bè 
=================


# Thành phần trong game
=================
🏗 1. Workspace
Chứa tất cả các đối tượng trong thế giới game (bản đồ, nhân vật, mô hình, v.v.).
Mọi thứ trong đây sẽ hiển thị trong game.

🎨 2. StarterGui 
====
Chứa UI (giao diện người dùng) như TextLabel, Buttons, Frames.
Mọi UI trong đây sẽ xuất hiện cho người chơi khi họ tham gia game.

👤 3. Players
====
Chứa danh sách người chơi hiện đang tham gia game.
Mỗi người chơi sẽ có một folder riêng trong đây khi họ vào game.

📜 4. StarterPack
====
Chứa công cụ (Tools) mà người chơi sẽ nhận được khi họ spawn vào game.
Ví dụ: Kiếm, súng, công cụ xây dựng, v.v.

🎭 5. StarterCharacterScripts
====
Chứa scripts được gắn vào character model của người chơi.
Dùng để thay đổi animation, tốc độ chạy, v.v.

🏠 6. StarterPlayer
====
Chứa cài đặt mặc định cho người chơi, như độ cao nhảy, tốc độ di chuyển, camera mode.

🎥 7. StarterCamera
====
Dùng để thiết lập cài đặt camera mặc định khi game bắt đầu.

🔍 8. ReplicatedStorage
====
Dùng để lưu các đối tượng cần đồng bộ giữa client và server.
Thường chứa Modules, Models, Sounds, RemoteEvents, RemoteFunctions.

🖥 9. ServerStorage
====
Lưu trữ dữ liệu chỉ server có thể truy cập (client không thể nhìn thấy).
Dùng để chứa map, NPC, scripts quan trọng.

🔄 10. ReplicatedFirst
====
Chứa các scripts/UI tải trước khi game bắt đầu.
Dùng để làm loading screen hoặc UI khởi động.

🔧 11. ServerScriptService
====
Chứa tất cả Server Scripts (scripts chạy trên server).
Các scripts trong đây sẽ không bị client thay đổi.

🎮 12. LocalScriptService (không có sẵn, nhưng có thể tạo)
====
Nơi đặt LocalScripts (scripts chạy trên client).
Thường dùng để điều khiển UI, hiệu ứng hình ảnh, input người chơi.

🏛 13. Lighting
Quản lý ánh sáng trong game.

Có thể thay đổi màu sắc, độ sáng, hiệu ứng trời mưa, sương mù, v.v.

🗺 14. Terrain
Chứa hệ thống địa hình (núi, cỏ, nước, sông, v.v.).

📜 15. HttpService
Dùng để gửi và nhận dữ liệu từ API bên ngoài (chỉ chạy trên server).

Dùng khi cần kết nối với cơ sở dữ liệu bên ngoài hoặc webhook.

📄 16. TextService
Quản lý font chữ và text filtering (lọc nội dung không phù hợp).

🏗 17. Teams
Chứa danh sách Teams (Đội nhóm) trong game.

Có thể dùng để chia team (ví dụ: Đội Xanh và Đội Đỏ trong game đối kháng).

🛠 18. Debris
Dùng để tự động dọn dẹp các object sau một khoảng thời gian.

Thường dùng để xóa hiệu ứng, đạn bay, rác trong game.

=================