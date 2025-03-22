using App.Models;

namespace App.Services
{
    public class PlanetService : List<PlanetModel>
    {
        public PlanetService()
        {
            Add(new PlanetModel {
                Id = 1, 
                Name = "Mercury", 
                NameVn= "Sao Thủy",
                Content= "Sao Thủy (0,31–0,59 au từ Mặt Trời) là hành tinh gần Mặt Trời nhất. Sao Thủy có cao nguyên và miệng núi lửa do va chạm thiên thạch chồng lên nhau. Vài tỉ năm trước, bề mặt Sao Thủy có núi lửa phun trào, tạo ra các đồng bằng bazan mịn tương tự như ở Mặt Trăng. Nhiệt độ trên bề mặt giữa ngày và đêm chênh nhau hơn 600 °C. Cấu tạo của hành tinh bao gồm khoảng 70% kim loại nằm chủ yếu ở lõi và 30% silicat ở lớp ngoài. Sao Thủy có lớp khí quyển siêu mỏng, được duy trì bởi nguyên tử sinh ra do gió Mặt Trời, sự bốc hơi của lớp băng đá hay các thiên thạch rơi vào. Sao Thủy không có vệ tinh tự nhiên nào."
            });
            Add(new PlanetModel
            {
                Id = 2,
                Name = "Venus",
                NameVn = "Sao Kim",
                Content = "Sao Kim (0,72–0,73 au) có khí quyển siêu dày, chứa chủ yếu là khí cacbonic và có mây chứa các hạt chất lỏng axit nhỏ li ti phản xạ lại ánh sáng Mặt Trời. Chính lớp mây này biến Sao Kim thành thiên thể sáng thứ 3 sau Mặt Trời và Mặt Trăng. Do hiệu ứng nhà kính từ khí cacbonic, tại bề mặt Sao Kim có áp suất lớn gấp 95 lần khí quyển Trái Đất và nhiệt độ 480 °C. Sao Kim không có từ quyển bảo vệ để chống lại gió Mặt Trời, điều này cho thấy bầu khí quyển được duy trì nhờ hoạt động núi lửa. Khoảng 90% bề mặt Sao Kim được phủ bởi dung nham. Sao Kim không có vệ tinh tự nhiên nào."
            });
            Add(new PlanetModel
            {
                Id = 3,
                Name = "Earth",
                NameVn = "Trái Đất",
                Content = "Trái Đất (0.98–1.02 au) là nơi duy nhất trong vũ trụ ta biết mà có sự sống và nước ở trạng thái lỏng trên bề mặt. Khoảng 78% bầu khí quyển của Trái Đất là nitơ và 21% là oxy, còn 1% là các chất khí khác. Hành tinh của ta có hệ thống khí hậu và thời tiết phức tạp với các vùng khí hậu đặc trưng riêng. Ba phần tư bề mặt Trái Đất được bao phủ bởi biển, một phần tư còn lại được bao phủ bởi thảm thực vật, sa mạc và băng. Từ quyển của Trái Đất bảo vệ bề mặt khỏi tia vũ trụ, góp phẩn bảo vệ bầu khí quyển và sự sống. Trái Đất có 1 vệ tinh tự nhiên là Mặt Trăng:\r\nMặt Trăng, theo thuyết va chạm lớn, được hình thành khi một vật thể cỡ Sao Hỏa đâm vào Trái Đất, tạo ra bụi cô lại thành Mặt Trăng. Bề mặt của Mặt Trăng được bao phủ bởi lớp bụi rất mịn và có nhiều hố va chạm. Những mảng tối lớn trên Mặt Trăng, gọi là \"biển\", được hình thành từ hoạt động núi lửa khi Mặt Trăng còn đang hình thành."
            });
            Add(new PlanetModel
            {
                Id = 4,
                Name = "Mars",
                NameVn = "Sao Hỏa",
                Content = "Sao Hỏa (1.38–1.67 au) có bán kính khoảng một nửa so với Trái Đất. Hầu hết bề mặt hành tinh có màu đỏ do oxit sắt, hai vùng cực được phủ bởi lớp băng trắng làm từ nước và cácbon dioxít. Sao Hỏa có một bầu khí quyển chủ yếu là cácbon dioxít với áp suất bề mặt chỉ bằng 0,6% so với áp suất của Trái Đất, vừa đủ để xuất hiện một số hiện tượng thời tiết trên khí quyển. Trên Sao Hỏa có các đồng bằng, cao nguyên và các miệng núi lửa. Có một thung lũng lớn dài 5000 km, rộng 200 km và sâu 7 km nằm trên Sao Hỏa tên là Valles Marineris, ngoài ra Sao Hỏa có núi lửa cao nhất hệ Mặt Trời tên là Olympus Mons. Sao Hoả có 2 vệ tinh là Deimos và Phobos.\r\nHai vệ tinh Deimos và Phobos đều có đặc điểm khá giống nhau."
            });
            Add(new PlanetModel
            {
                Id = 5,
                Name = "Jupiter",
                NameVn = "Sao Mộc",
                Content = "Sao Mộc (4,95–5,46 au) là hành tinh lớn nhất trong hệ Mặt Trời, nặng hơn 318 lần Trái Đất. Ngoài phần lõi nhỏ bằng đá, khí quyển của Sao Mộc chủ yếu là hydro và heli. Khí quyển Sao Mộc phức tạp, bao gồm nhiều lớp và vòng khí không phân chia rõ ràng. Do trong lòng Sao Mộc có nhiệt độ cao nên trên bề mặt luôn có bão. Trên bề mặt có cơn bão xoáy khổng lồ có đường kính gấp 3 lần Trái Đất, được gọi là Vết Đỏ Lớn. Sao Mộc có từ quyển rất mạnh, đủ để bẻ hướng bức xạ ion hóa từ Mặt Trời và tạo ra cực quang. Sao Mộc có 95 vệ tinh tự nhiên đã được phát hiện."
            });
            Add(new PlanetModel
            {
                Id = 6,
                Name = "Saturn",
                NameVn = "Sao Thổ",
                Content = "Sao Thổ (9,08–10,12 au) có hệ thống vành đai rực rỡ có thể nhìn thấy được qua kính viễn vọng, có cấu tạo từ mảnh băng và đá nhỏ. Sao Thổ chủ yếu được cấu tạo từ hydro và heli giống như giống như Sao Mộc. Ở cực Bắc và Nam, Sao Thổ với lý do chưa rõ có cơn bão hình lục giác lớn hơn đường kính Trái Đất. Sao Thổ có từ quyển yếu hơn Sao Mộc, chỉ tạo được các cực quang yếu. Tính đến năm 2024, Sao Thổ có 146 vệ tinh tự nhiên đã được phát hiện."
            });
            Add(new PlanetModel
            {
                Id = 7,
                Name = "Uranus",
                NameVn = "Sao Thiên Vương",
                Content = "Sao Thiên Vương (18,3–20,1 au) quay quanh Mặt Trời với trục nghiêng gần như vuông góc với quỹ đạo. Điều này làm khí quyển có sự thay đổi mùa khắc nghiệt khi quay quanh quỹ đạo. Lớp ngoài của Sao Thiên Vương có màu xanh lam nhạt do metan. Ở sâu bên trong khí quyển ẩn chứa nhiều bí ẩn về các hiện tượng khí hậu, chẳng hạn như nhiệt độ thấp ở trong lõi, sự hình thành của mây và lốc xoáy. Tính đến năm 2024, Sao Thiên Vương có 28 vệ tinh tự nhiên đã được phát hiện."
            });
            Add(new PlanetModel
            {
                Id = 8,
                Name = "Neptune",
                NameVn = "Sao Hải Vương",
                Content = "Sao Hải Vương (29,9–30,5 au) là hành tinh xa nhất trong hệ Mặt Trời. Lớp ngoài của Sao Hải Vượng có màu xanh lam nhạt do metan, với những cơn bão hình đốm đen thỉnh thoảng xuất hiện trên bề mặt. Giống như Sao Thiên Vương, nhiều hiện tượng khí quyển của Sao Hải Vương vẫn chưa có lời giải thích, chẳng hạn như nhiệt độ của tầng nhiệt quyển hay độ nghiêng bất thường của từ quyển. Tính đến năm 2024, Sao Hải Vương có 16 vệ tinh tự nhiên đã được phát hiện."
            });
        }
    }
}
