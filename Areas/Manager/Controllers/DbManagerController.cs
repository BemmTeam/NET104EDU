using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NET104.Entities;
using NET104.Helper;

namespace NET104.Areas.Controllers
{
    [Area("Manager")]
    [Route("Manager/[controller]/[action]")]
    public class DbManagerController : Controller
    {

        // localhost:5001/Manager/DbManager/Index
        private readonly ShopContext _context;
        public DbManagerController(ShopContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            return View(); // 1 phiên -> viewData
        }

        [TempData]
        public string Message { get; set; }

        [TempData]
        public string MessageType { get; set; }
        public async Task<IActionResult> InsertCategory()
        {
            List<Category> categories = new(){

                new Category(){
                   Name = "Apple"
                },

                new Category(){
                   Name = "Samsung"
                },

                new Category(){
                   Name = "Oppo"
                },
                  new Category(){
                   Name = "Xiaomi"
                },
            };

            try
            {
                await _context.Categories.AddRangeAsync(categories);
                await _context.SaveChangesAsync();
                Message = "Thêm dữ liệu thành công";
                MessageType = MessageHelper.success;
            }
            catch
            {
                Message = "Thêm dữ liệu thất bại";
                MessageType = MessageHelper.error;

                return RedirectToAction(nameof(Index)); //2 phiên -> Temdata

            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> InsertProduct()
        {
            List<Product> products = new()
         {
               new Product() { Name = "iPhone 13 Pro Max 128GB" , Quantity = 123 , Price = 30490000 , Desc = "iPhone 13 Pro Max xứng đáng là một chiếc iPhone lớn nhất, mạnh mẽ nhất và có thời lượng pin dài nhất từ trước đến nay sẽ cho bạn trải nghiệm tuyệt vời, từ những tác vụ bình thường cho đến các ứng dụng chuyên nghiệp." , Image_Url="product1.png" , Category_Id = 1},
                new Product() { Name = "iPhone 13 Pro 128GB " , Quantity = 20 , Price = 27490000 , Desc = "Tận hưởng tốc độ khó tin trên chiếc smartphone nhanh nhất thế giới, iPhone 13 Pro với màn hình ProMotion 120Hz đột phá, bộ vi xử lý A15 Bionic cho hiệu năng không đối thủ, thời lượng pin vượt trội và bộ 3 camera được nâng cấp đáng kể, xứng đáng là chiếc điện thoại đầu bảng trên thị trường" , Image_Url="product2.png" , Category_Id = 1},
                new Product() { Name = "iPhone 11" , Quantity = 123 , Price = 16230000 , Desc = "Apple đã chính thức trình làng bộ 3 siêu phẩm iPhone 11, trong đó phiên bản iPhone 11 64GB có mức giá rẻ nhất nhưng vẫn được nâng cấp mạnh mẽ như iPhone Xr ra mắt trước đó." , Image_Url="product3.png" , Category_Id = 1},
                new Product() { Name = "iPhone 13 " , Quantity = 13 , Price = 23590000 , Desc = "Trong khi sức hút đến từ bộ 4 phiên bản iPhone 12 vẫn chưa nguội đi, thì Apple đã mang đến cho người dùng một siêu phẩm mới iPhone 13 - điện thoại có nhiều cải tiến thú vị sẽ mang lại những trải nghiệm hấp dẫn nhất cho người dùng." , Image_Url="product4.png" , Category_Id = 1},
                new Product() { Name = "iPhone 13 Mini" , Quantity = 43 , Price = 12490000 , Desc = "iPhone 13 mini được Apple ra mắt với hàng loạt nâng cấp về cấu hình và các tính năng hữu ích, lại có thiết kế vừa vặn. Chiếc điện thoại này hứa hẹn là một thiết bị hoàn hảo hướng tới những khách hàng thích sự nhỏ gọn nhưng vẫn giữ được sự mạnh mẽ bên trong. " , Image_Url="product5.png" , Category_Id = 1},
                new Product() { Name = "Samsung Galaxy A03 3GB" , Quantity = 34 , Price = 16390000 , Desc = "Samsung Galaxy A03 là chiếc điện thoại Galaxy A đầu tiên của nhà Samsung trong năm 2022 tại thị trường Việt Nam. Đây là sản phẩm có mức giá dễ tiếp cận, có camera chính đến 48 MP, pin 5000 mAh thoải mái sử dụng cả ngày." , Image_Url="product6.png" , Category_Id = 2},
                new Product() { Name = "Samsung Galaxy A52s 5G 128GB " , Quantity = 423 , Price = 15490000 , Desc = "Samsung đã chính thức giới thiệu chiếc điện thoại Galaxy A52s 5G đến người dùng, đây phiên bản nâng cấp của Galaxy A52 5G ra mắt cách đây không lâu, với ngoại hình không đổi nhưng được nâng cấp đáng kể về thông số cấu hình bên trong." , Image_Url="product7.png" , Category_Id = 2},
                new Product() { Name = "Samsung Galaxy Z Fold3 5G 256GB" , Quantity = 444 , Price = 35090000 , Desc = "Galaxy Z Fold3 5G, chiếc điện thoại được nâng cấp toàn diện về nhiều mặt, đặc biệt đây là điện thoại màn hình gập đầu tiên trên thế giới có camera ẩn (08/2021). Sản phẩm sẽ là một “cú hit” của Samsung góp phần mang đến những trải nghiệm mới cho người dùng." , Image_Url="product8.png" , Category_Id = 2},
                new Product() { Name = "Samsung Galaxy Z Flip3 5G 128GB" , Quantity = 87    , Price = 19000000 , Desc = "Trong sự kiện Galaxy Unpacked hồi 11/8, Samsung đã chính thức trình làng mẫu điện thoại màn hình gập thế hệ mới mang tên Galaxy Z Flip3 5G 128GB. Đây là một siêu phẩm với màn hình gập dạng vỏ sò cùng nhiều điểm cải tiến và thông số ấn tượng, sản phẩm chắc chắn sẽ thu hút được rất nhiều sự quan tâm của người dùng, đặc biệt là phái nữ." , Image_Url="product9.png" , Category_Id = 2},
                new Product() { Name = "Samsung Galaxy Note 20" , Quantity = 20 , Price = 15090000 , Desc = "Tháng 8/2020, Galaxy Note 20 chính thức được lên kệ, với thiết kế camera trước nốt ruồi quen thuộc, cụm camera hình chữ nhật mới lạ cùng với vi xử lý Exynos 990 cao cấp của chính Samsung chắc hẳn sẽ mang lại một trải nghiệm thú vị cùng hiệu năng mạnh mẽ." , Image_Url="product10.png" , Category_Id = 2},
                new Product() { Name = "OPPO Reno7 Z 5G" , Quantity = 13 , Price = 10490000 , Desc = "OPPO đã trình làng mẫu Reno7 Z 5G với thiết kế OPPO Glow độc quyền, camera mang hiệu ứng như máy DSLR chuyên nghiệp cùng viền sáng kép, máy có một cấu hình mạnh mẽ và đạt chứng nhận xếp hạng A về độ mượt." , Image_Url="product11.png" , Category_Id = 3},
                new Product() { Name = "OPPO Reno6 5G" , Quantity = 80 , Price = 12990000 , Desc = "Sau khi ra mắt OPPO Reno5 chưa lâu thì OPPO lại cho ra mẫu smartphone mới mang tên OPPO Reno6 với hàng loạt cải tiến mới về ngoại hình bên ngoài lẫn hiệu năng bên trong, mang đến trải nghiệm vượt bật cho người dùng." , Image_Url="product12.png" , Category_Id = 3},
                new Product() { Name = "OPPO A95" , Quantity = 123 , Price = 30490000 , Desc = "Bên cạnh phiên bản 5G, OPPO còn bổ sung phiên bản OPPO A95 4G với giá thành phải chăng tập trung vào thiết kế năng động, sạc nhanh và hiệu năng đa nhiệm ấn tượng sẽ giúp cho cuộc sống của bạn thêm phần hấp dẫn, ngập tràn niềm vui." , Image_Url="product13.png" , Category_Id = 3},
                new Product() { Name = "OPPO Reno4 Pro" , Quantity = 30 , Price = 34000000 , Desc = "OPPO chính thức trình làng chiếc smartphone có tên OPPO Reno4 Pro. Máy trang bị cấu hình vô cùng cao cấp với vi xử lý chip Snapdragon 720G, bộ 4 camera đến 48 MP ấn tượng, cùng công nghệ sạc siêu nhanh 65 W nhưng được bán với mức giá vô ưu đãi, dễ tiếp cận." , Image_Url="product14.png" , Category_Id = 3},
                new Product() { Name = "OPPO A74 5G" , Quantity = 13 , Price = 17490000 , Desc = "OPPO A74 5G mẫu điện thoại có kết nối 5G với mức giá tốt của OPPO. Máy có thiết kế tinh tế, màn hình 90 Hz mượt mà và cụm camera làm đẹp AI sẽ là những điểm nhấn “đáng tiền” trên mẫu điện thoại này." , Image_Url="product15.png" , Category_Id = 3},
                new Product() { Name = "Xiaomi 11T 5G 128GB" , Quantity = 43 , Price = 10490000 , Desc = "Xiaomi 11T đầy nổi bật với thiết kế vô cùng trẻ trung, màn hình AMOLED, bộ 3 camera sắc nét và viên pin lớn đây sẽ là mẫu smartphone của Xiaomi thỏa mãn mọi nhu cầu giải trí, làm việc và là niềm đam mê sáng tạo của bạn. " , Image_Url="product16.png" , Category_Id = 4},
                new Product() { Name = "Xiaomi Redmi Note 11 Pro" , Quantity = 76 , Price = 18490000 , Desc = "Điểm nổi bật ở phần thiết kế của Redmi Note 11 Pro chính là cụm camera khá lớn và lồi so với mặt lưng, mặt lưng có chất liệu bằng kính đã được làm phẳng đi. Khung viền bằng nhựa cũng được bo tròn và vát phẳng rất liền mạch, mức độ hoàn thiện tốt, không có hiện tượng ọp ẹp khi mình sử dụng chiếc máy này." , Image_Url="product17.png" , Category_Id = 4},
                new Product() { Name = "Xiaomi 12 " , Quantity = 30 , Price = 10490000 , Desc = "Xiaomi đang dần khẳng định chỗ đứng của mình trong phân khúc điện thoại flagship khi cho ra mắt Xiaomi 12 với mức giá khá ấn tượng, máy có một thiết kế gọn gàng, hiệu năng mạnh mẽ, màn hình hiển thị chi tiết cùng khả năng chụp ảnh sắc nét nhờ trang bị ống kính đến từ Sony." , Image_Url="product18.png" , Category_Id = 4},
                new Product() { Name = "Xiaomi 11T Pro 5G 8GB" , Quantity = 13 , Price = 13490000 , Desc = "Xiaomi 11T Pro 5G 8GB sử dụng con chip Snapdragon 888 mạnh mẽ, camera chính 108 MP, hỗ trợ sạc nhanh 120 W, màn hình rộng với tốc độ làm tươi lên đến 120 Hz, tận hưởng trải nghiệm tuyệt vời trong từng khoảnh khắc." , Image_Url="product19.png" , Category_Id = 4},
                new Product() { Name = "Xiaomi 11 Lite 5G NE " , Quantity = 60 , Price = 19049000 , Desc = "Xiaomi 11 Lite 5G NE một phiên bản có ngoại hình rất giống với Mi 11 Lite được ra mắt trước đây. Chiếc smartphone này của Xiaomi mang trong mình một hiệu năng ổn định, thiết kế sang trọng và màn hình lớn đáp ứng tốt các tác vụ hằng ngày của bạn một cách dễ dàng." , Image_Url="product20.png" , Category_Id = 4},
         };

            try
            {
                await _context.Products.AddRangeAsync(products);
                await _context.SaveChangesAsync();
                Message = "Thêm dữ liệu thành công";
                MessageType = MessageHelper.success;
            }
            catch
            {
                Message = "Thêm dữ liệu thất bại";
                MessageType = MessageHelper.error;

                return RedirectToAction(nameof(Index)); //2 phiên -> Temdata

            }
            return RedirectToAction(nameof(Index));

        }
    }
}
