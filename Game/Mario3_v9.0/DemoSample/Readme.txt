1. Struct ViewPort thêm vào hàm khởi tạo, truyền vào các
tham số : x, y, width, height

2. Biến thể hiện nhân vật mariodemo không còn được khai báo là thành viên trong class GameMario.
Thay vào đó, biến thể hiện nhân vật mariodemo được khai báo là biến toàn cục và khởi tạo ngay trong file mariodemo.h
--> Đoạn code khởi tạo nhân vật mariodemo trong file GameMario.h không còn nữa

3. Các biến thể hiện kích thước màn hình, cũng như thể hiện kích thước ViewPort không còn được khai báo trong
class Game.h nữa
 Thay vào đó, nó được khai báo trong class GlobalObject, tiện cho việc khai báo Camera.

4. Class MyRectangle thêm vào phương thức SetIndex(int index), không chỉ set lại giá trị index, mà set luôn cả RECT
theo index đó, đồng thời các biến như Tick để đếm giờ set về 0, frametime thể hiện khoảng thời gian giữa 2 frame đưa
về giá trị mặc đinh, biến NextFrame thể hiện được phép sang Frame khác hay không set về False.
--> Do đó, trong phương thức Reset() bị xóa, thay vào đó là gọi phương thức SetIndex(0).

5. Ở class GameMario, thêm vào phương thức private
UpdateViewPort(), mục đích update lại tọa độ của ViewPort
sau mỗi Frame Game. ViewPort theo dõi Mario, nên tọa 
độ ViewPort được tính dựa vào tọa độ Mario



///////////////// 12/2/2015 /////////////////
+ va chạm: chua xet va cham voi van toc am
+ #pragma once, ennif, define, va endif giai quyet include qua lai lan nhau