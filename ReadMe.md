 1. Thư viện "summernote" để tích hợp vào trang web:
	
	1.1. Để phần description, content hiển thị như là docx thì ta thêm thư viện của "summernote" vào 
 	1.2. Cài đặt thư viện "summernote" trong libman.
	1.3. Sau đó thêm id = "gì cũng được" vào thẻ textarea ****
	1.4. thêm các script và link thông qua cdnjs (Đặt dưới thẻ textarea)
	1.5. Ví dụ đẻ kích hoạt thì thêm script sau:
		<script>
			$(document).ready(function() {
				$('#gì cũng được').summernote({
				height: 120,
					toolbar: [
						['style', ['style']],
						['font', ['bold', 'italic', 'underline', 'clear']],
						['fontname', ['fontname']],
						['color', ['color']],
						['para', ['ul', 'ol', 'paragraph']],
						['height', ['height']],
						['table', ['table']],
						['insert', ['link', 'picture', 'video']],
						['view', ['fullscreen', 'codeview', 'help']]
					]
				});
			});
		</script>
	1.6. Để code này chạy và hiển thị thì ta phải nạp nó vào sau jquery tại _Layout.cshtml_ .
	1.7. Thì để giải quyết vấn đề này ta mở section Script rồi thêm vào trong section đó là được
	1.8. Tức là cho hết phần code bên trên vào trong section Script. Thì phần code trên sẽ nằm sau các jquery,...
	1.9. Còn 1 cách nữa để xử lý vấn đề này là chuyển các script trong trang _Layout.cshtml_ lên trên đầu trang(css) xong bỏ script đi thì kết quả vẫn đúng.

2. Sử dụng thư viện "summernote" như là 1 partial:

	2.1. Tạo 1 partial view và đặt tên là "_SummernotePartial.cshtml"
	2.1. Trong file này thì ta thêm các script và link của "summernote" vào.
	2.2. vì phần kích hoạt là 1 id nên ta tạo 1 model để truyền id vào.
	2.3. Trong Model ta khai báo các thuộc tính như là: IdEditor,(bool) LoadLibrarym, height, toolbar
	2.4. Mình dùng 1 biến bool để kiểm tra xem có cần load thư viện không.(vì khi ta tạo 2 partial nó sẽ gọi thư viện 2 lần).
	2.5. tạo contructor để khởi tạo giá trị mặc định cho các thuộc tính.
	2.6. và sau đó ta dùng code sau để tạo kiểu cho textarea:
		@{
			var summernote = new App.Models.SummernoteModel("gì cũng được");								
		}
		<partial name="_SummernotePartial" model="summernote" />
	2.7. Ở trong code thì các id sẽ được định nghĩa qua asp-for.

3. Tích hợp chọn ảnh để điền vào nội dung.
					
	3.1. Với trường hợp ta điền link vào thì không sao nhưng nếu ta chọn file trong local thì ta phải làm thêm các bước.
	3.2. Tích hợp thư viện elFinder. Dùng nuget để thêm package: elFinder.NetCore (thêm 2 thư viện như trong libman)
	3.3. Trong Areas tạo ra 1 folder tên là Files và thêm controller cho nó.
	3.4. Trong Views tạo ra file: /Views/FileManager/Index.cshtml và copy _Layout.cshtml_ vào trong Views/Shared/FileManagerLayout.cshtml
	3.5. bỏ hết giữ lại body và renderbody.
	3.6. Trong _Layout.cshtml thì thêm thẻ link và script của elFinder.
		(<link rel="stylesheet" href="~/lib/jqueryui/themes/base/theme.css" />
		<link rel="stylesheet" href="~/lib/jqueryui/themes/base/jquery-ui.css" />
		<link rel="stylesheet" href="~/lib/elfinder/css/elfinder.full.css" />
		<link rel="stylesheet" href="~/lib/elfinder/css/theme.min.css" />
		<link rel="stylesheet" href="~/css/elfinder-material-theme/Material/css/theme-gray.css" /> *bo*
    
		<script src="~/lib/jquery/dist/jquery.min.js"></script> *bo*
		<script src="~/lib/jqueryui/jquery-ui.min.js"></script>
		<script src="~/lib/elfinder/js/elfinder.min.js"></script> )
	3.7. Xử lý các Models, controller và views để nó hiển thị ra như 1 page. Sau đó thì tích hợp nó vào trong summernote.(xem thêm tại xtlb.net/asp-net-core-mvc-tich-hop-trinh-quan-ly-file-vao-website.html)

1. 