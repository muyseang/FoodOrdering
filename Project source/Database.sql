Food Ordering

-- CREATE DATABASE
CREATE DATABASE FoodOrderingDb;
USE FoodOrderingDb;

-- CREATE TABLE
CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Username VARCHAR(255) NOT NULL,
    Password VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    Role VARCHAR(50) NOT NULL,  
);


CREATE TABLE FoodItems (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Description TEXT NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    Category VARCHAR(100) NOT NULL,
    ImageUrl VARCHAR(500) NULL,
);


CREATE TABLE CartItems (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    FoodItemId INT NOT NULL,
    FoodName VARCHAR(255) NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    Quantity INT NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_CartItems_Users FOREIGN KEY (UserId) REFERENCES Users(Id),
    CONSTRAINT FK_CartItems_FoodItems FOREIGN KEY (FoodItemId) REFERENCES FoodItems(Id)
);


CREATE TABLE Orders (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    OrderDate DATETIME NOT NULL,
    TotalAmount DECIMAL(18,2) NOT NULL,
    Status VARCHAR(50) NOT NULL,         -- Pending, Paid, InProgress, Completed
    PaymentStatus VARCHAR(50) NOT NULL,  -- Pending, Paid
    CONSTRAINT FK_Orders_Users FOREIGN KEY (UserId) REFERENCES Users(Id)
);


CREATE TABLE OrderItems (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    OrderId INT NOT NULL,
    FoodItemId INT NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_OrderItems_Orders FOREIGN KEY (OrderId) REFERENCES Orders(Id),
    CONSTRAINT FK_OrderItems_FoodItems FOREIGN KEY (FoodItemId) REFERENCES FoodItems(Id)
);

-- INSERT DATA
INSERT INTO Users (Id, Username, Password, Role)
VALUES (1, 'admin', '$2a$12$DCFivOnraf6V7aeMTeey8e9v9nRbetjV1ebRQTNn4fAuBxv2qyajq', 'Admin');


INSERT INTO FoodItems (Id, Name, Description, Price, Category, ImageUrl) VALUES
(1, 'Classic Cheeseburger', 'Juicy beef patty with melted cheese, lettuce, tomato, and our special sauce on a toasted bun.', 12.99, 'A La Carte', ''),
(2, 'Margherita Pizza', 'Traditional pizza with fresh mozzarella, tomatoes, basil, and olive oil on a crispy thin crust.', 15.50, 'A La Carte', ''),
(3, 'Caesar Salad', 'Crisp romaine lettuce with parmesan cheese, croutons, and our homemade Caesar dressing.', 9.99, 'Rice and Salad', ''),
(4, 'Grilled Chicken Breast', 'Tender grilled chicken breast seasoned with herbs, served with roasted vegetables.', 18.75, 'Fried Chicken', ''),
(5, 'Fish & Chips', 'Beer-battered fish fillets with golden fries and mushy peas, served with tartar sauce.', 16.25, 'A La Carte', ''),
(6, 'Pepperoni Pizza', 'Classic pizza topped with spicy pepperoni and mozzarella cheese on our signature dough.', 17.00, 'A La Carte', ''),
(7, 'Chocolate Brownie', 'Rich, fudgy chocolate brownie served warm with vanilla ice cream and chocolate sauce.', 7.50, 'Snack', ''),
(8, 'Chicken Wings', 'Crispy chicken wings tossed in your choice of buffalo, BBQ, or honey mustard sauce.', 11.99, 'Fried Chicken', ''),
(9, 'Veggie Burger', 'House-made plant-based patty with avocado, sprouts, and chipotle mayo on a whole grain bun.', 13.50, 'A La Carte', ''),
(10, 'Tiramisu', 'Classic Italian dessert with layers of coffee-soaked ladyfingers and mascarpone cream.', 8.99, 'Coffee', ''),
(11, 'Greek Salad', 'Fresh mixed greens with feta cheese, olives, tomatoes, and cucumber in olive oil dressing.', 10.75, 'Rice and Salad', ''),
(12, 'Loaded Nachos', 'Crispy tortilla chips loaded with cheese, jalapeños, sour cream, and guacamole.', 9.50, 'Snack', '');


