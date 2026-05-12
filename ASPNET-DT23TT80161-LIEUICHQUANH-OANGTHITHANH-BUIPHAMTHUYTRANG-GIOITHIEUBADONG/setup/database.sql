INSERT INTO Categories (Name, Description)
VALUES 
(N'Giới thiệu', N'Các bài viết giới thiệu tổng quan về biển Ba Động'),
(N'Lịch sử', N'Các bài viết về lịch sử và văn hóa địa phương'),
(N'Ẩm thực', N'Các bài viết giới thiệu món ăn và hải sản'),
(N'Kinh nghiệm du lịch', N'Các bài viết chia sẻ kinh nghiệm tham quan'),
(N'Hình ảnh', N'Các bài viết và hình ảnh nổi bật');

INSERT INTO Posts (Title, Summary, Content, ImageUrl, CreatedAt, CategoryId)
VALUES
(
    N'Giới thiệu tổng quan về khu du lịch biển Ba Động',
    N'Biển Ba Động là một trong những điểm du lịch nổi bật của tỉnh Trà Vinh.',
    N'Khu du lịch biển Ba Động thuộc tỉnh Trà Vinh, là địa điểm tham quan được nhiều du khách biết đến với vẻ đẹp hoang sơ, không khí trong lành và cảnh quan biển đặc trưng của vùng đồng bằng sông Cửu Long. Website được xây dựng nhằm giới thiệu thông tin, hình ảnh và các bài viết liên quan đến khu du lịch biển Ba Động.',
    N'/images/badong1.jpg',
    GETDATE(),
    1
),
(
    N'Ẩm thực đặc trưng tại biển Ba Động',
    N'Du khách có thể thưởng thức nhiều món hải sản tươi ngon khi đến biển Ba Động.',
    N'Khi đến biển Ba Động, du khách có thể thưởng thức các món ăn đặc trưng như tôm, cua, ghẹ, cá biển và nhiều loại hải sản tươi sống. Đây là một trong những yếu tố thu hút khách du lịch đến tham quan và trải nghiệm.',
    N'/images/badong2.jpg',
    GETDATE(),
    3
),
(
    N'Kinh nghiệm tham quan biển Ba Động',
    N'Một số kinh nghiệm giúp chuyến tham quan biển Ba Động thuận lợi hơn.',
    N'Du khách nên chuẩn bị phương tiện di chuyển, kiểm tra thời tiết trước khi đi và lựa chọn thời gian phù hợp để tham quan. Ngoài ra, có thể kết hợp tham quan các địa điểm văn hóa, tâm linh và thưởng thức ẩm thực địa phương.',
    N'/images/badong3.jpg',
    GETDATE(),
    4
);

