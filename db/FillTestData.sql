USE [Supercharge]
GO

INSERT INTO [dbo].[User]([FirstName],[LastName],[Email],[IsActive],[CreatedBy],[CreatedOnUtc],[ModifiedBy],[ModifiedOnUtc])
VALUES 
('Kolos','Kazal','koloskazal@gmail.com',1,1,GETUTCDATE(),1,GETUTCDATE()),
('Jakab','Gipsz','jakabGipsz@gmail.com',1,1,GETUTCDATE(),1,GETUTCDATE());
GO

INSERT INTO [Hotel] (Name, Address, IsActive, CreatedBy, CreatedOnUtc, ModifiedBy, ModifiedOnUtc)
VALUES 
('Hotel Budapest', 'Budapest District 1', 1, 1, GETUTCDATE(), 1, GETUTCDATE()),
('Danube Hotel', 'Budapest District 2', 1, 1, GETUTCDATE(), 1, GETUTCDATE()),
('Royal Palace Hotel', 'Budapest District 5', 1, 1, GETUTCDATE(), 1, GETUTCDATE()),
('City Center Inn', 'Budapest District 6', 1, 1, GETUTCDATE(), 1, GETUTCDATE()),
('Green Park Hotel', 'Budapest District 7', 1, 1, GETUTCDATE(), 1, GETUTCDATE());
GO



INSERT INTO [Price] (HotelId, Amount, PriceType, StartDate, EndDate, IsActive, CreatedBy, CreatedOnUtc, ModifiedBy, ModifiedOnUtc)
VALUES 
(1, 100.00, 'Standard', '2023-01-01', '2023-12-31', 1, 1, GETUTCDATE(), 1, GETUTCDATE()),
(1, 150.00, 'Deluxe', '2023-01-01', '2023-12-31', 1, 1, GETUTCDATE(), 1, GETUTCDATE()),
(2, 120.00, 'Standard', '2023-01-01', '2023-12-31', 1, 1, GETUTCDATE(), 1, GETUTCDATE()),
(2, 170.00, 'Deluxe', '2023-01-01', '2023-12-31', 1, 1, GETUTCDATE(), 1, GETUTCDATE()),
(3, 130.00, 'Standard', '2023-01-01', '2023-12-31', 1, 1, GETUTCDATE(), 1, GETUTCDATE()),
(3, 180.00, 'Deluxe', '2023-01-01', '2023-12-31', 1, 1, GETUTCDATE(), 1, GETUTCDATE()),
(4, 110.00, 'Standard', '2023-01-01', '2023-12-31', 1, 1, GETUTCDATE(), 1, GETUTCDATE()),
(4, 160.00, 'Deluxe', '2023-01-01', '2023-12-31', 1, 1, GETUTCDATE(), 1, GETUTCDATE()),
(5, 140.00, 'Standard', '2023-01-01', '2023-12-31', 1, 1, GETUTCDATE(), 1, GETUTCDATE()),
(5, 190.00, 'Deluxe', '2023-01-01', '2023-12-31', 1, 1, GETUTCDATE(), 1, GETUTCDATE());
GO

-- Inserting rooms for Hotel Budapest (HotelId = 1)
INSERT INTO [Room] (HotelId,PriceId, RoomNumber, Type, IsActive, CreatedBy, CreatedOnUtc, ModifiedBy, ModifiedOnUtc, NumberOfPlaces, Description)
VALUES 
(1,1, '101', 'Single', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 1, 'Single room with city view'),
(1,1, '102', 'Double', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 2, 'Double room with two beds'),
(1,2, '103', 'Suite', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 4, 'Suite with living area and city view'),
(1,1, '201', 'Single', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 1, 'Single room with city view'),
(1,1, '202', 'Double', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 2, 'Double room with two beds'),
(1,2, '203', 'Suite', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 4, 'Suite with living area and city view'),
(1,1, '301', 'Single', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 1, 'Single room with city view'),
(1,1, '302', 'Double', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 2, 'Double room with two beds'),
(1,2, '303', 'Suite', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 4, 'Suite with living area and city view')

go


-- Inserting rooms for Danube Hotel (HotelId = 2)
INSERT INTO [Room] (HotelId,PriceId, RoomNumber, Type, IsActive, CreatedBy, CreatedOnUtc, ModifiedBy, ModifiedOnUtc, NumberOfPlaces, Description)
VALUES 
(2,3, '101', 'Single', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 1, 'Single room with city view'),
(2,3, '102', 'Double', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 2, 'Double room with two beds'),
(2,4, '103', 'Suite', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 4, 'Suite with living area and city view'),
(2,3, '201', 'Single', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 1, 'Single room with city view'),
(2,3, '202', 'Double', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 2, 'Double room with two beds'),
(2,4, '203', 'Suite', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 4, 'Suite with living area and city view'),
(2,3, '301', 'Single', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 1, 'Single room with city view'),
(2,3, '302', 'Double', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 2, 'Double room with two beds'),
(2,4, '303', 'Suite', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 4, 'Suite with living area and city view')

go



-- Inserting rooms for Royal Palace Hotel (HotelId = 3)
INSERT INTO [Room] (HotelId,PriceId, RoomNumber, Type, IsActive, CreatedBy, CreatedOnUtc, ModifiedBy, ModifiedOnUtc, NumberOfPlaces, Description)
VALUES 
(3,5, '101', 'Single', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 1, 'Single room with city view'),
(3,5, '102', 'Double', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 2, 'Double room with two beds'),
(3,6, '103', 'Suite', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 4, 'Suite with living area and city view'),
(3,5, '201', 'Single', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 1, 'Single room with city view'),
(3,5, '202', 'Double', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 2, 'Double room with two beds'),
(3,6, '203', 'Suite', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 4, 'Suite with living area and city view'),
(3,5, '301', 'Single', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 1, 'Single room with city view'),
(3,5, '302', 'Double', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 2, 'Double room with two beds'),
(3,6, '303', 'Suite', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 4, 'Suite with living area and city view')

go


-- Inserting rooms for City Center Inn (HotelId = 4)
INSERT INTO [Room] (HotelId,PriceId, RoomNumber, Type, IsActive, CreatedBy, CreatedOnUtc, ModifiedBy, ModifiedOnUtc, NumberOfPlaces, Description)
VALUES 
(4,7, '101', 'Single', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 1, 'Single room with city view'),
(4,7, '102', 'Double', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 2, 'Double room with two beds'),
(4,8, '103', 'Suite', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 4, 'Suite with living area and city view'),
(4,7, '201', 'Single', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 1, 'Single room with city view'),
(4,7, '202', 'Double', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 2, 'Double room with two beds'),
(4,8, '203', 'Suite', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 4, 'Suite with living area and city view'),
(4,7, '301', 'Single', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 1, 'Single room with city view'),
(4,7, '302', 'Double', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 2, 'Double room with two beds'),
(4,8, '303', 'Suite', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 4, 'Suite with living area and city view')

go

-- Inserting rooms for Green Park Hotel (HotelId = 5)
INSERT INTO [Room] (HotelId,PriceId, RoomNumber, Type, IsActive, CreatedBy, CreatedOnUtc, ModifiedBy, ModifiedOnUtc, NumberOfPlaces, Description)
VALUES 
(5,9, '101', 'Single', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 1, 'Single room with city view'),
(5,9, '102', 'Double', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 2, 'Double room with two beds'),
(5,10, '103', 'Suite', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 4, 'Suite with living area and city view'),
(5,9, '201', 'Single', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 1, 'Single room with city view'),
(5,9, '202', 'Double', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 2, 'Double room with two beds'),
(5,10, '203', 'Suite', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 4, 'Suite with living area and city view'),
(5,9, '301', 'Single', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 1, 'Single room with city view'),
(5,9, '302', 'Double', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 2, 'Double room with two beds'),
(5,10, '303', 'Suite', 1, 1, GETUTCDATE(), 1, GETUTCDATE(), 4, 'Suite with living area and city view')

go


INSERT INTO [Visitor] (FirstName, LastName, Email, Phone, IsActive, CreatedBy, CreatedOnUtc, ModifiedBy, ModifiedOnUtc)
VALUES 
('John', 'Doe', 'john.doe@example.com', '123-456-7890', 1, 1, GETUTCDATE(), 1, GETUTCDATE()),
('Jane', 'Doe', 'jane.doe@example.com', '098-765-4321', 1, 1, GETUTCDATE(), 1, GETUTCDATE()),
('Jim', 'Beam', 'jim.beam@example.com', '555-555-5555', 1, 1, GETUTCDATE(), 1, GETUTCDATE()),
('Jack', 'Daniels', 'jack.daniels@example.com', '666-666-6666', 1, 1, GETUTCDATE(), 1, GETUTCDATE()),
('Johnny', 'Walker', 'johnny.walker@example.com', '777-777-7777', 1, 1, GETUTCDATE(), 1, GETUTCDATE()),
('Jill', 'Valentine', 'jill.valentine@example.com', '888-888-8888', 1, 1, GETUTCDATE(), 1, GETUTCDATE()),
('Chris', 'Redfield', 'chris.redfield@example.com', '999-999-9999', 1, 1, GETUTCDATE(), 1, GETUTCDATE()),
('Leon', 'Kennedy', 'leon.kennedy@example.com', '111-111-1111', 1, 1, GETUTCDATE(), 1, GETUTCDATE()),
('Claire', 'Redfield', 'claire.redfield@example.com', '222-222-2222', 1, 1, GETUTCDATE(), 1, GETUTCDATE()),
('Ada', 'Wong', 'ada.wong@example.com', '333-333-3333', 1, 1, GETUTCDATE(), 1, GETUTCDATE());
GO

INSERT INTO [Booking] (VisitorId, RoomId, StartDate, EndDate, CreatedBy, CreatedOnUtc, ModifiedBy, ModifiedOnUtc)
VALUES 
(5, 1, '2023-04-01', '2023-04-05', 1, GETUTCDATE(), 1, GETUTCDATE()),
(5, 2, '2023-05-01', '2023-05-05', 1, GETUTCDATE(), 1, GETUTCDATE()),
(5, 3, '2023-06-01', '2023-06-05', 1, GETUTCDATE(), 1, GETUTCDATE()),
(5, 4, '2023-07-01', '2023-07-05', 1, GETUTCDATE(), 1, GETUTCDATE()),
(5, 5, '2023-08-01', '2023-08-05', 1, GETUTCDATE(), 1, GETUTCDATE());
GO