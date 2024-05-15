# Giới thiệu
Nội dung bài viết này đề cập đến kiểu giá trị và kiểu tham chiếu trong C# (và có thể một số ngôn ngữ khác như Java). C# không có kiểu con trỏ và không cần người dùng quản lý bộ nhớ. Nhưng về mặt gốc rễ, con trỏ và quản lý bộ nhớ vẫn tồn tại và chúng ta cần hiểu về cách thức mà nó hoạt động để hiểu rõ kiểu giá trị, kiểu tham thiếu, từ khóa ref và out. Mình đã từng dính bug rất nghiêm trọng đối với các tham chiếu, vì thế, mình nghĩ mọi người cần phải nắm chắc kiến thức này để tránh rắc rối về sau.

Mình sẽ tránh không đề cập đến con trỏ trong nội dung bên dưới.

# Stack - Heap
Stack và Heap là hai dạng bộ nhớ để lưu trữ giá trị của các biến trong chương trình.

Stack lưu trữ các biến có độ dài cố định như là các kiểu dữ liệu nguyên thủy, struct, array. Vì có độ dài cố định nên việc đọc ghi dữ liệu trong Stack nhanh hơn, không mất thời gian tính toán vị trí các ô nhớ.

Heap lưu trữ dữ liệu các dạng biến có độ dài không cố định như string (string khác với char array), object. Các dữ liệu này không lưu trong stack được vì khi nó thay đổi, sẽ tốn chi phí lớn để cập nhật lại tất cả các biến trong stack (do địa chỉ, index bị sai khác đi khi cấp phát bọ nhớ cho biến kia).

# Kiểu giá trị - Kiểu tham chiếu
Kiểu giá trị là kiểu mà giá trị của nó được lưu trữ trong Stack là đủ.

Kiểu tham chiếu là kiểu mà nó phải lưu cả ở Stack lẫn Heap.

Khi bạn khai báo một biến, và đoạn mã được nạp vào CPU, thông tin về biến được đưa vào cpu là kiểu (suy ra được kích thước bộ nhớ cho nó) và địa chỉ (chỉ mục cũng được) của nó trong Stack, bất kể là kiểu giá trị hay kiểu tham chiếu. Điểm khác biệt là:

- Kiểu giá trị thì lưu giá trị của nó trong Stack (kiểu int32 sẽ lưu 4 byte của nó trong Stack, kiểu struct ví dụ như DateTime sẽ lưu Ngày Tháng Năm Giờ Phút Giây Mili Giây là 7 số int32, 28 byte vào Stack).
- Kiểu tham chiếu thì lưu trong Stack địa chỉ của bộ nhớ dữ liệu của biến trong Heap. Địa chỉ của bộ nhỡ có thể coi là kiểu giá trị vì kích thước cố định (chip 32bit thì địa chỉ 4 byte, 64 bit thì 8 byte ...).

Khi chúng ta sửa đổi dữ liệu của kiểu giá trị, chúng ta sửa đổi giá trị của nó trong Stack. Khi chúng ta truyền kiểu giá trị vào hàm, một biến cục bộ được sinh ra, được cấp phát một ô trong Stack, copy giá trị từ biến nguồn vào.

Khi chúng ta sửa đổi dữ liệu của kiểu tham chiếu, chúng ta sửa đổi giá trị của nó trong Heap. Nhưng khi chúng ta truyền kiểu tham chiếu vào hàm, một biến cục bộ được sinh ra để nhận giá trị của nó trong Stack chứ không phải giá trị trong Heap, tức là nhận lấy địa chỉ của dữ liệu trong Heap. Đây là hai biến độc lập có hai ô nhớ độc lập trong Stack có cùng một giá trị là địa chỉ của dữ liệu trong Heap.

Đó là nền tảng để các bạn hiểu về ref và vì sao out lại an toàn hơn. Mình sẽ giải thích chi tiết hơn trong code.

# Code
Phần code sẽ chạy qua các trường hợp có thể xảy ra khi làm việc với kiểu giá trị, kiểu tham chiếu, ref và out. Trong code sẽ có comment giải thích cho từng trường hợp.

# reference variable
Phần này có lẽ không quá quan trọng. Qua phần trên các bạn đã hiểu bản chất nên biến tham chiếu không còn là dấu hỏi nữa.
