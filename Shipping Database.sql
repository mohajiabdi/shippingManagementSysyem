drop database shipping

CREATE DATABASE Shipping;
USE Shipping;


-- User Table
CREATE TABLE UserDt (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(50) NOT NULL,
    Role NVARCHAR(20) NOT NULL CHECK (Role IN ('Admin', 'Staff'))
);
select * from Userdt

-- Customers Table
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    CustomerName VARCHAR(100),
    ContactEmail VARCHAR(100),
    ContactPhone VARCHAR(20) not null unique,
    DateOfBirth DATE,
    Address VARCHAR(255)
);
drop table customers

-- Ships Table
CREATE TABLE Ships (
    ShipID INT PRIMARY KEY IDENTITY(1,1),
    ShipName VARCHAR(100) NOT NULL,
    CurrentLocation VARCHAR(100),
    Status VARCHAR(20) CHECK (Status IN ('Docked', 'At Sea', 'Maintenance'))
);
SELECT c.ContainerNumericID, c.ContainerID, c.ShipID,sh.ShipName, c.Status,c.LastKnownPort FROM Containers c, Ships sh Where c.ShipID = sh.ShipID

-- Ports Table
CREATE TABLE Ports (
    PortID INT PRIMARY KEY IDENTITY(1,1),
    PortName VARCHAR(100) NOT NULL,
    Country VARCHAR(50)
);

-- Containers Table
CREATE TABLE Containers (
    ContainerNumericID INT IDENTITY(1000,1) PRIMARY KEY, -- Numeric part
    ContainerID AS ('C' + CAST(ContainerNumericID AS VARCHAR(10))), -- Computed ID (e.g., C1001, C1002)
    ShipID INT,
    Status VARCHAR(20) CHECK (Status IN ('Loaded', 'In Transit', 'Unloaded')),
    LastKnownPort VARCHAR(100),
    Description VARCHAR(255), -- General description of the container's contents
    FOREIGN KEY (ShipID) REFERENCES Ships(ShipID)
);
select * from Containers

-- Updating 
UPDATE Containers
SET Status = 'Loaded';

-- ShippingOrders Table
CREATE TABLE ShippingOrders (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT,
    ShipID INT,
    DeparturePortID INT,
    ArrivalPortID INT,
    OrderDate DATE DEFAULT GETDATE(), -- Default to today's date
    Status VARCHAR(20) CHECK (Status IN ('Booked', 'In Transit', 'Delivered', 'Canceled')),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (ShipID) REFERENCES Ships(ShipID),
    FOREIGN KEY (DeparturePortID) REFERENCES Ports(PortID),
    FOREIGN KEY (ArrivalPortID) REFERENCES Ports(PortID)
);

ALTER TABLE ShippingOrders
ADD DeliveryDuration INT;


truncate table ShippingOrders

select o.OrderID, o.CustomerID,c.CustomerName, o.ShipID,s.ShipName,o.DeparturePortID, p.PortName, o.ArrivalPortID,p.PortId, o.Status
from ShippingOrders o, Customers c, Ships s, Ports p
Where o.CustomerID = c.CustomerID and o.ShipId = s.ShipID and o.DeparturePortID = p.PortID and
o.ArrivalPortID = p.PortID;


-- Inserting Customers
-- Insert 100 customers with Islamic names, realistic emails, and ages between 20 and 40
INSERT INTO Customers (CustomerName, ContactEmail, ContactPhone, DateOfBirth, Address)
VALUES
('Ahmed Ali', 'ahmed.ali@gmail.com', '612345678', '1985-03-15', 'Mogadishu, Somalia'),
('Fatima Hassan', 'fatima.hassan@hotmail.com', '712345678', '1990-07-22', 'Mombasa, Kenya'),
('Mohamed Abdi', 'mohamed.abdi@yahoo.com', '612345679', '1988-11-30', 'Berbera, Somalia'),
('Aisha Omar', 'aisha.omar@gmail.com', '712345679', '1992-05-10', 'Djibouti City, Djibouti'),
('Yusuf Ahmed', 'yusuf.ahmed@hotmail.com', '612345680', '1987-09-25', 'Dar es Salaam, Tanzania'),
('Khadija Mohamed', 'khadija.mohamed@yahoo.com', '712345680', '1991-12-12', 'Zanzibar, Tanzania'),
('Omar Farah', 'omar.farah@gmail.com', '612345681', '1986-04-18', 'Port Sudan, Sudan'),
('Halima Ali', 'halima.ali@hotmail.com', '712345681', '1993-08-05', 'Massawa, Eritrea'),
('Abdullahi Yusuf', 'abdullahi.yusuf@yahoo.com', '612345682', '1989-02-14', 'Assab, Eritrea'),
('Zainab Abdi', 'zainab.abdi@gmail.com', '712345682', '1994-06-20', 'Maputo, Mozambique'),
('Ali Hassan', 'ali.hassan@hotmail.com', '612345683', '1984-10-08', 'Beira, Mozambique'),
('Maryam Ahmed', 'maryam.ahmed@yahoo.com', '712345683', '1995-01-17', 'Nacala, Mozambique'),
('Hassan Omar', 'hassan.omar@gmail.com', '612345684', '1983-07-03', 'Lamu, Kenya'),
('Amina Mohamed', 'amina.mohamed@hotmail.com', '712345684', '1996-03-29', 'Kismayo, Somalia'),
('Ibrahim Ali', 'ibrahim.ali@yahoo.com', '612345685', '1982-12-11', 'Bosaso, Somalia'),
('Fadumo Abdi', 'fadumo.abdi@gmail.com', '712345685', '1997-09-14', 'Hargeisa, Somalia'),
('Mustafa Ahmed', 'mustafa.ahmed@hotmail.com', '612345686', '1981-05-19', 'Port Louis, Mauritius'),
('Safiya Yusuf', 'safiya.yusuf@yahoo.com', '712345686', '1998-04-23', 'Victoria, Seychelles'),
('Abdirahman Hassan', 'abdirahman.hassan@gmail.com', '612345687', '1980-08-27', 'Toamasina, Madagascar'),
('Asha Omar', 'asha.omar@hotmail.com', '712345687', '1999-11-09', 'Antsiranana, Madagascar'),
('Abdiwali Mohamed', 'abdiwali.mohamed@yahoo.com', '612345688', '1979-06-13', 'Moroni, Comoros'),
('Hawa Ali', 'hawa.ali@gmail.com', '712345688', '2000-02-28', 'Mutsamudu, Comoros'),
('Mohamud Abdi', 'mohamud.abdi@hotmail.com', '612345689', '1978-03-07', 'Jeddah, Saudi Arabia'),
('Fartun Ahmed', 'fartun.ahmed@yahoo.com', '712345689', '2001-07-16', 'Dubai, UAE'),
('Ahmed Yusuf', 'ahmed.yusuf@gmail.com', '612345690', '1977-10-21', 'Salalah, Oman'),
('Nasra Omar', 'nasra.omar@hotmail.com', '712345690', '2002-05-04', 'Mumbai, India'),
('Abdulahi Hassan', 'abdulahi.hassan@yahoo.com', '612345691', '1976-12-30', 'Chennai, India'),
('Zahra Mohamed', 'zahra.mohamed@gmail.com', '712345691', '2003-09-12', 'Colombo, Sri Lanka'),
('Farah Ali', 'farah.ali@hotmail.com', '612345692', '1975-04-18', 'Chittagong, Bangladesh'),
('Ayan Abdi', 'ayan.abdi@yahoo.com', '712345692', '2004-01-25', 'Yangon, Myanmar'),
('Yasin Ahmed', 'yasin.ahmed@gmail.com', '612345693', '1974-08-09', 'Bangkok, Thailand'),
('Haniya Yusuf', 'haniya.yusuf@hotmail.com', '712345693', '2005-03-14', 'Ho Chi Minh City, Vietnam'),
('Ismail Omar', 'ismail.omar@yahoo.com', '612345694', '1973-11-22', 'Singapore, Singapore'),
('Sadia Mohamed', 'sadia.mohamed@gmail.com', '712345694', '2006-06-07', 'Jakarta, Indonesia'),
('Abdirashid Hassan', 'abdirashid.hassan@hotmail.com', '612345695', '1972-02-15', 'Manila, Philippines'),
('Layla Ali', 'layla.ali@yahoo.com', '712345695', '2007-10-30', 'Shanghai, China'),
('Abdulaziz Abdi', 'abdulaziz.abdi@gmail.com', '612345696', '1971-07-04', 'Hong Kong, China'),
('Muna Ahmed', 'muna.ahmed@hotmail.com', '712345696', '2008-04-19', 'Guangzhou, China'),
('Abdulkadir Yusuf', 'abdulkadir.yusuf@yahoo.com', '612345697', '1970-09-26', 'Tokyo, Japan'),
('Naima Omar', 'naima.omar@gmail.com', '712345697', '2009-12-11', 'Yokohama, Japan'),
('Abdirahim Mohamed', 'abdirahim.mohamed@hotmail.com', '612345698', '1969-05-28', 'Busan, South Korea'),
('Filsan Ali', 'filsan.ali@yahoo.com', '712345698', '2010-08-03', 'Incheon, South Korea'),
('Abdullah Abdi', 'abdullah.abdi@gmail.com', '612345699', '1968-01-17', 'Kaohsiung, Taiwan'),
('Hodan Ahmed', 'hodan.ahmed@hotmail.com', '712345699', '2011-03-22', 'Kuala Lumpur, Malaysia'),
('Abdisalam Hassan', 'abdisalam.hassan@yahoo.com', '612345700', '1967-06-09', 'Penang, Malaysia'),
('Asli Omar', 'asli.omar@gmail.com', '712345700', '2012-09-15', 'Phnom Penh, Cambodia'),
('Abdirazak Mohamed', 'abdirazak.mohamed@hotmail.com', '612345701', '1966-12-24', 'Vientiane, Laos'),
('Hamdi Ali', 'hamdi.ali@yahoo.com', '712345701', '2013-02-28', 'Hanoi, Vietnam'),
('Abdulqadir Yusuf', 'abdulqadir.yusuf@gmail.com', '612345702', '1965-04-13', 'Dhaka, Bangladesh'),
('Fawzia Ahmed', 'fawzia.ahmed@hotmail.com', '712345702', '2014-07-19', 'Karachi, Pakistan'),
('Abdirahman Abdi', 'abdirahman.abdi@yahoo.com', '612345703', '1964-10-05', 'Colombo, Sri Lanka'),
('Nimo Omar', 'nimo.omar@gmail.com', '712345703', '2015-01-10', 'Male, Maldives'),
('Abdulahi Mohamed', 'abdulahi.mohamed@hotmail.com', '612345704', '1963-03-27', 'Port Victoria, Seychelles'),
('Hafsa Ali', 'hafsa.ali@yahoo.com', '712345704', '2016-06-02', 'Port Louis, Mauritius'),
('Abdirahim Hassan', 'abdirahim.hassan@gmail.com', '612345705', '1962-08-18', 'Toamasina, Madagascar'),
('Maryan Ahmed', 'maryan.ahmed@hotmail.com', '712345705', '2017-11-23', 'Antsiranana, Madagascar'),
('Abdulaziz Yusuf', 'abdulaziz.yusuf@yahoo.com', '612345706', '1961-05-14', 'Moroni, Comoros'),
('Aisha Omar', 'aisha.omar@gmail.com', '712345706', '2018-09-29', 'Mutsamudu, Comoros'),
('Abdirahman Abdi', 'abdirahman.abdi@hotmail.com', '612345707', '1960-12-04', 'Jeddah, Saudi Arabia'),
('Fadumo Ali', 'fadumo.ali@yahoo.com', '712345707', '2019-02-09', 'Dubai, UAE'),
('Abdullahi Mohamed', 'abdullahi.mohamed@gmail.com', '612345708', '1959-07-20', 'Salalah, Oman'),
('Khadija Ahmed', 'khadija.ahmed@hotmail.com', '712345708', '2020-04-25', 'Mumbai, India'),
('Abdirahim Omar', 'abdirahim.omar@yahoo.com', '612345709', '1958-10-11', 'Chennai, India'),
('Asha Yusuf', 'asha.yusuf@gmail.com', '712345709', '2021-01-16', 'Colombo, Sri Lanka'),
('Abdulqadir Abdi', 'abdulqadir.abdi@hotmail.com', '612345710', '1957-03-03', 'Chittagong, Bangladesh'),
('Hani Ali', 'hani.ali@yahoo.com', '712345710', '2022-06-08', 'Yangon, Myanmar'),
('Abdirahim Hassan', 'abdirahim.hassan@gmail.com', '612345711', '1956-09-13', 'Bangkok, Thailand'),
('Fartun Ahmed', 'fartun.ahmed@hotmail.com', '712345711', '2023-12-18', 'Ho Chi Minh City, Vietnam'),
('Abdulaziz Omar', 'abdulaziz.omar@yahoo.com', '612345712', '1955-02-22', 'Singapore, Singapore'),
('Naima Mohamed', 'naima.mohamed@gmail.com', '712345712', '2024-05-27', 'Jakarta, Indonesia'),
('Abdirahim Ali', 'abdirahim.ali@hotmail.com', '612345713', '1954-08-01', 'Manila, Philippines'),
('Hodan Abdi', 'hodan.abdi@yahoo.com', '712345713', '2025-11-06', 'Shanghai, China'),
('Abdulahi Yusuf', 'abdulahi.yusuf@gmail.com', '612345714', '1953-01-12', 'Hong Kong, China'),
('Maryam Ahmed', 'maryam.ahmed@hotmail.com', '712345714', '2026-04-17', 'Guangzhou, China'),
('Abdirahim Omar', 'abdirahim.omar@yahoo.com', '612345715', '1952-07-23', 'Tokyo, Japan'),
('Asha Mohamed', 'asha.mohamed@gmail.com', '712345715', '2027-10-28', 'Yokohama, Japan'),
('Abdulqadir Ali', 'abdulqadir.ali@hotmail.com', '612345716', '1951-12-03', 'Busan, South Korea'),
('Fadumo Hassan', 'fadumo.hassan@yahoo.com', '712345716', '2028-03-09', 'Incheon, South Korea'),
('Abdirahim Ahmed', 'abdirahim.ahmed@gmail.com', '612345717', '1950-05-15', 'Kaohsiung, Taiwan'),
('Khadija Omar', 'khadija.omar@hotmail.com', '712345717', '2029-08-20', 'Kuala Lumpur, Malaysia'),
('Abdulaziz Yusuf', 'abdulaziz.yusuf@yahoo.com', '612345718', '1949-11-25', 'Penang, Malaysia'),
('Aisha Abdi', 'aisha.abdi@gmail.com', '712345718', '2030-02-28', 'Phnom Penh, Cambodia');






-- Insert Ports for East Africa, India, China, etc.
INSERT INTO Ports (PortName, Country) VALUES
('Mombasa Port', 'Kenya'),
('Dar es Salaam Port', 'Tanzania'),
('Djibouti Port', 'Djibouti'),
('Port Sudan', 'Sudan'),
('Eritrea Port', 'Eritrea'),
('Port of Mogadishu', 'Somalia'),
('Port of Berbera', 'Somalia'),
('Port of Kismayo', 'Somalia'),
('Kochi Port', 'India'),
('Mumbai Port', 'India'),
('Chennai Port', 'India'),
('Visakhapatnam Port', 'India'),
('Port of Shanghai', 'China'),
('Port of Shenzhen', 'China'),
('Port of Guangzhou', 'China'),
('Hong Kong Port', 'China'),
('Port of Singapore', 'Singapore'),
('Port of Colombo', 'Sri Lanka'),
('Port of Jebel Ali', 'UAE'),
('Port of Salalah', 'Oman');




-- Insert Ships
INSERT INTO Ships (ShipName, CurrentLocation, Status) VALUES
('MS Safina', 'Mombasa Port', 'At Sea'),
('SS Indomitable', 'Dar es Salaam Port', 'Maintenance'),
('MV Makka', 'Djibouti Port', 'Docked'),
('MV Serenity', 'Port Sudan', 'Docked'),
('SS Horizon', 'Eritrea Port', 'Docked'),
('MV Somali Star', 'Port of Mogadishu', 'Docked'),
('MV Ocean Queen', 'Port of Berbera', 'Docked'),
('SS Eastwind', 'Port of Kismayo', 'Docked'),
('MV Chennai Express', 'Kochi Port', 'Docked'),
('MV Mumbai Seaway', 'Mumbai Port', 'Docked'),
('SS Lotus', 'Chennai Port', 'Docked'),
('MV Andaman Victory', 'Visakhapatnam Port', 'Docked'),
('MV Yangtze River', 'Port of Shanghai', 'Docked'),
('MV Dragon Pearl', 'Port of Shenzhen', 'Docked'),
('SS Great Wall', 'Port of Guangzhou', 'Docked'),
('MV Red Dragon', 'Hong Kong Port', 'Docked'),
('MV Ocean Breeze', 'Port of Singapore', 'Docked'),
('MV Ceylon King', 'Port of Colombo', 'Docked'),
('SS Jebel Ali Dawn', 'Port of Jebel Ali', 'Docked'),
('MV Salalah Voyager', 'Port of Salalah', 'Docked'),
('MV Ocean Pioneer', 'Mombasa Port', 'Docked'),
('SS Challenger', 'Dar es Salaam Port', 'Docked'),
('MV Horizon Explorer', 'Djibouti Port', 'Docked'),
('SS Triton', 'Port Sudan', 'Docked'),
('MV Equator Spirit', 'Eritrea Port', 'Docked'),
('MV Blue Star', 'Port of Mogadishu', 'Docked'),
('MV Victory Horizon', 'Port of Berbera', 'Docked'),
('SS Navigator', 'Port of Kismayo', 'Docked'),
('MV Seaway Explorer', 'Kochi Port', 'Docked'),
('MV Global Wave', 'Mumbai Port', 'Docked'),
('SS Titan', 'Chennai Port', 'Docked'),
('MV Ocean Pearl', 'Visakhapatnam Port', 'Docked'),
('MV Neptune Star', 'Port of Shanghai', 'Docked'),
('MV Golden Horizon', 'Port of Shenzhen', 'Docked'),
('MV Pacific Glory', 'Port of Guangzhou', 'Docked'),
('SS Oceanic', 'Hong Kong Port', 'Docked'),
('MV Coral Breeze', 'Port of Singapore', 'Docked'),
('MV Diamond Star', 'Port of Colombo', 'Docked'),
('SS Silver Wave', 'Port of Jebel Ali', 'Docked'),
('MV Desert Jewel', 'Port of Salalah', 'Docked'),
('SS Sea Explorer', 'Mombasa Port', 'Docked'),
('MV Star Cruiser', 'Dar es Salaam Port', 'Docked'),
('SS Sea Voyager', 'Djibouti Port', 'Docked'),
('MV Ocean Breeze', 'Port Sudan', 'Docked'),
('MV Royal Quest', 'Eritrea Port', 'Docked'),
('MV Northern Light', 'Port of Mogadishu', 'Docked'),
('SS Ocean Glory', 'Port of Berbera', 'Docked'),
('MV Western Spirit', 'Port of Kismayo', 'Docked'),
('MV Global Explorer', 'Kochi Port', 'Docked'),
('MV Majestic Wave', 'Mumbai Port', 'Docked');









-- Insert Containers for each Ship (5 containers per ship, assuming each ship can carry 5 containers)
INSERT INTO Containers (ShipID, Status, LastKnownPort, Description) VALUES
-- ShipID 1 (MS Safina)
(1, 'Loaded', 'Mombasa Port', 'Electronics'),
(1, 'In Transit', 'Dar es Salaam Port', 'Clothing'),
(1, 'Unloaded', 'Djibouti Port', 'Construction Materials'),
(1, 'Loaded', 'Port Sudan', 'Automobiles'),
(1, 'In Transit', 'Eritrea Port', 'Furniture'),

-- ShipID 2 (SS Indomitable)
(2, 'Loaded', 'Port of Mogadishu', 'Groceries'),
(2, 'In Transit', 'Port of Berbera', 'Toys'),
(2, 'Unloaded', 'Port of Kismayo', 'Beverages'),
(2, 'Loaded', 'Kochi Port', 'Spices'),
(2, 'In Transit', 'Mumbai Port', 'Medical Supplies'),

-- ShipID 3 (MV Makka)
(3, 'Loaded', 'Chennai Port', 'Textiles'),
(3, 'In Transit', 'Visakhapatnam Port', 'Electronics'),
(3, 'Unloaded', 'Port of Shanghai', 'Footwear'),
(3, 'Loaded', 'Port of Shenzhen', 'Petroleum Products'),
(3, 'In Transit', 'Port of Guangzhou', 'Furniture'),

-- ShipID 4 (MV Serenity)
(4, 'Loaded', 'Hong Kong Port', 'Consumer Goods'),
(4, 'In Transit', 'Port of Singapore', 'Machinery'),
(4, 'Unloaded', 'Port of Colombo', 'Chemicals'),
(4, 'Loaded', 'Port of Jebel Ali', 'Pharmaceuticals'),
(4, 'In Transit', 'Port of Salalah', 'Food Ingredients'),

-- ShipID 5 (SS Horizon)
(5, 'Loaded', 'Mombasa Port', 'Heavy Machinery'),
(5, 'In Transit', 'Dar es Salaam Port', 'Oil & Gas'),
(5, 'Unloaded', 'Djibouti Port', 'Construction Equipment'),
(5, 'Loaded', 'Port Sudan', 'Automotive Parts'),
(5, 'In Transit', 'Eritrea Port', 'Electronics'),

-- ShipID 6 (MV Somali Star)
(6, 'Loaded', 'Port of Berbera', 'Wheat'),
(6, 'In Transit', 'Kochi Port', 'Textiles'),
(6, 'Unloaded', 'Mumbai Port', 'Foodstuffs'),
(6, 'Loaded', 'Port of Shanghai', 'Furniture'),
(6, 'In Transit', 'Port of Jebel Ali', 'Clothing'),

-- ShipID 7 (MV Ocean Queen)
(7, 'Loaded', 'Visakhapatnam Port', 'Machinery'),
(7, 'In Transit', 'Hong Kong Port', 'Medical Supplies'),
(7, 'Unloaded', 'Port of Colombo', 'Electronics'),
(7, 'Loaded', 'Port of Salalah', 'Automotive Parts'),
(7, 'In Transit', 'Port of Shenzhen', 'Construction Materials'),

-- ShipID 8 (SS Eastwind)
(8, 'Loaded', 'Port of Kismayo', 'Raw Materials'),
(8, 'In Transit', 'Port of Guangzhou', 'Chemical Goods'),
(8, 'Unloaded', 'Port of Mogadishu', 'Textiles'),
(8, 'Loaded', 'Port of Jebel Ali', 'Clothing'),
(8, 'In Transit', 'Port of Singapore', 'Pharmaceuticals'),

-- ShipID 9 (MV Chennai Express)
(9, 'Loaded', 'Port of Berbera', 'Electrical Appliances'),
(9, 'In Transit', 'Port of Colombo', 'Automotive Parts'),
(9, 'Unloaded', 'Port of Mombasa', 'Electronics'),
(9, 'Loaded', 'Port of Dubai', 'Chemicals'),
(9, 'In Transit', 'Port of Salalah', 'Food Ingredients'),

-- ShipID 10 (MV Mumbai Seaway)
(10, 'Loaded', 'Port of Kismayo', 'Furniture'),
(10, 'In Transit', 'Port of Chennai', 'Spices'),
(10, 'Unloaded', 'Port of Shenzhen', 'Wheat'),
(10, 'Loaded', 'Port of Shanghai', 'Beverages'),
(10, 'In Transit', 'Port of Hong Kong', 'Construction Materials'),

-- ShipID 11 (SS Lotus)
(11, 'Loaded', 'Port of Visakhapatnam', 'Chemicals'),
(11, 'In Transit', 'Port of Djibouti', 'Raw Materials'),
(11, 'Unloaded', 'Port of Dar es Salaam', 'Furniture'),
(11, 'Loaded', 'Port of Shanghai', 'Medical Supplies'),
(11, 'In Transit', 'Port of Jebel Ali', 'Automotive Parts'),

-- ShipID 12 (MV Andaman Victory)
(12, 'Loaded', 'Port of Colombo', 'Consumer Electronics'),
(12, 'In Transit', 'Port of Dubai', 'Clothing'),
(12, 'Unloaded', 'Port of Mombasa', 'Textiles'),
(12, 'Loaded', 'Port of Salalah', 'Automotive Parts'),
(12, 'In Transit', 'Port of Kismayo', 'Chemicals'),

-- ShipID 13 (MV Yangtze River)
(13, 'Loaded', 'Port of Berbera', 'Consumer Goods'),
(13, 'In Transit', 'Port of Chennai', 'Pharmaceuticals'),
(13, 'Unloaded', 'Port of Shanghai', 'Automotive Parts'),
(13, 'Loaded', 'Port of Colombo', 'Machinery'),
(13, 'In Transit', 'Port of Hong Kong', 'Furniture'),

-- ShipID 14 (MV Dragon Pearl)
(14, 'Loaded', 'Port of Dubai', 'Textiles'),
(14, 'In Transit', 'Port of Kismayo', 'Construction Equipment'),
(14, 'Unloaded', 'Port of Dar es Salaam', 'Medical Supplies'),
(14, 'Loaded', 'Port of Salalah', 'Chemicals'),
(14, 'In Transit', 'Port of Jebel Ali', 'Furniture'),

-- ShipID 15 (SS Great Wall)
(15, 'Loaded', 'Port of Shanghai', 'Consumer Electronics'),
(15, 'In Transit', 'Port of Shenzhen', 'Food Ingredients'),
(15, 'Unloaded', 'Port of Mombasa', 'Automobiles'),
(15, 'Loaded', 'Port of Guangzhou', 'Furniture'),
(15, 'In Transit', 'Port of Colombo', 'Pharmaceuticals'),

-- ShipID 16 to ShipID 50 (Additional entries)
(16, 'Loaded', 'Port of Hong Kong', 'Raw Materials'),
(17, 'In Transit', 'Port of Salalah', 'Clothing'),
(18, 'Unloaded', 'Port of Mombasa', 'Electronics'),
(19, 'Loaded', 'Port of Jebel Ali', 'Machinery'),
(20, 'In Transit', 'Port of Colombo', 'Automotive Parts'),
(21, 'Unloaded', 'Port of Shanghai', 'Textiles'),
(22, 'Loaded', 'Port of Kismayo', 'Furniture'),
(23, 'In Transit', 'Port of Berbera', 'Chemicals'),
(24, 'Unloaded', 'Port of Dubai', 'Consumer Goods'),
(25, 'Loaded', 'Port of Colombo', 'Electronics'),
(26, 'In Transit', 'Port of Jebel Ali', 'Foodstuffs'),
(27, 'Unloaded', 'Port of Kismayo', 'Medical Supplies'),
(28, 'Loaded', 'Port of Salalah', 'Spices'),
(29, 'In Transit', 'Port of Djibouti', 'Beverages'),
(30, 'Unloaded', 'Port of Chennai', 'Construction Materials'),
(31, 'Loaded', 'Port of Guangzhou', 'Textiles'),
(32, 'In Transit', 'Port of Shanghai', 'Automotive Parts'),
(33, 'Unloaded', 'Port of Visakhapatnam', 'Consumer Electronics'),
(34, 'Loaded', 'Port of Mumbai', 'Food Ingredients'),
(35, 'In Transit', 'Port of Dar es Salaam', 'Furniture'),
(36, 'Unloaded', 'Port of Shenzhen', 'Clothing'),
(37, 'Loaded', 'Port of Mombasa', 'Chemicals'),
(38, 'In Transit', 'Port of Colombo', 'Medical Supplies'),
(39, 'Unloaded', 'Port of Salalah', 'Electronics'),
(40, 'Loaded', 'Port of Berbera', 'Wheat'),
(41, 'In Transit', 'Port of Shanghai', 'Automobiles'),
(42, 'Unloaded', 'Port of Kismayo', 'Textiles'),
(43, 'Loaded', 'Port of Hong Kong', 'Furniture'),
(44, 'In Transit', 'Port of Jebel Ali', 'Raw Materials'),
(45, 'Unloaded', 'Port of Chennai', 'Electronics'),
(46, 'Loaded', 'Port of Dubai', 'Spices'),
(47, 'In Transit', 'Port of Guangzhou', 'Chemicals'),
(48, 'Unloaded', 'Port of Mombasa', 'Consumer Goods'),
(49, 'Loaded', 'Port of Visakhapatnam', 'Food Ingredients'),
(50, 'In Transit', 'Port of Colombo', 'Textiles');








-- Insert data into ShippingOrders table
INSERT INTO ShippingOrders (CustomerID, ShipID, DeparturePortID, ArrivalPortID, Status, DeliveryDuration)
VALUES
(1, 1, 1, 2, 'Booked', 10),
(2, 2, 2, 3, 'In Transit', 7),
(3, 3, 3, 4, 'Delivered', 15),
(4, 4, 4, 5, 'Canceled', 5),
(5, 5, 5, 6, 'Booked', 12),
(6, 6, 6, 7, 'In Transit', 9),
(7, 7, 7, 8, 'Delivered', 8),
(8, 8, 8, 9, 'Canceled', 3),
(9, 9, 9, 10, 'Booked', 14),
(10, 10, 1, 2, 'In Transit', 10),
(11, 11, 2, 3, 'Delivered', 6),
(12, 12, 3, 4, 'Canceled', 11),
(13, 13, 4, 5, 'Booked', 13),
(14, 14, 5, 6, 'In Transit', 7),
(15, 15, 6, 7, 'Delivered', 10),
(16, 16, 7, 8, 'Canceled', 9),
(17, 17, 8, 9, 'Booked', 8),
(18, 18, 9, 10, 'In Transit', 4),
(19, 19, 1, 2, 'Delivered', 14),
(20, 20, 2, 3, 'Canceled', 5),
(21, 21, 3, 4, 'Booked', 10),
(22, 22, 4, 5, 'In Transit', 6),
(23, 23, 5, 6, 'Delivered', 11),
(24, 24, 6, 7, 'Canceled', 7),
(25, 25, 7, 8, 'Booked', 9),
(26, 26, 8, 9, 'In Transit', 6),
(27, 27, 9, 10, 'Delivered', 15),
(28, 28, 1, 2, 'Canceled', 4),
(29, 29, 2, 3, 'Booked', 13),
(30, 30, 3, 4, 'In Transit', 12),
(31, 31, 4, 5, 'Delivered', 8),
(32, 32, 5, 6, 'Canceled', 5),
(33, 33, 6, 7, 'Booked', 10),
(34, 34, 7, 8, 'In Transit', 14),
(35, 35, 8, 9, 'Delivered', 7),
(36, 36, 9, 10, 'Canceled', 11),
(37, 37, 1, 2, 'Booked', 9),
(38, 38, 2, 3, 'In Transit', 8),
(39, 39, 3, 4, 'Delivered', 12),
(40, 40, 4, 5, 'Canceled', 6),
(41, 41, 5, 6, 'Booked', 10),
(42, 42, 6, 7, 'In Transit', 7),
(43, 43, 7, 8, 'Delivered', 9),
(44, 44, 8, 9, 'Canceled', 5),
(45, 45, 9, 10, 'Booked', 13),
(46, 46, 1, 2, 'In Transit', 8),
(47, 47, 2, 3, 'Delivered', 10),
(48, 48, 3, 4, 'Canceled', 7),
(49, 49, 4, 5, 'Booked', 9),
(50, 50, 5, 6, 'In Transit', 6);
