create table Organizer(
Id int primary key identity(1,1),
Name nvarchar(60) not null check(len(trim(Name))<>''),
Email varchar(70)not null check(len(trim(Email))<>'') unique
);
create table Venue(
Id int primary key identity(1,1),
Name Nvarchar(100) not null check(len(trim(Name))<>''),
Location nvarchar(100) not null check(len(trim(Location))<>''),
Capacity int not null check(Capacity > 0)
);
create table Event(
Id int primary key identity(1,1),
Title nvarchar(100) not null check(len(trim(Title))<>''),
OrganizerId int,
VenueId int,
EventDate Datetime not null default(GetDate()),
foreign key(OrganizerId) references Organizer(Id),
foreign key(VenueId) references Venue(Id)
);
create table Attendee(
Id int primary key identity(1,1),
Name nvarchar(100) not null check(len(trim(Name))<>''),
Email varchar(100) not null check(len(trim(Email))<>'') unique
);
create table Ticket(
Id int primary key identity(1,1),
EventId int,
AttendeeId int,
Price numeric(10,2) not null check(Price > 0),
CheckedIn DateTime null,
foreign key(EventId) references Event(Id),
foreign key(AttendeeId) references Attendee(Id)
);

INSERT INTO Organizer (Name, Email)
VALUES
('Ahmed Mohamed', 'ahmed@gmail.com'),
('Mohamed Ali', 'mohamed@gmail.com'),
('Sara Hassan', 'sara@gmail.com'),
('Omar Khaled', 'omar@gmail.com'),
('Mariam Adel', 'mariam@gmail.com'),
('Youssef Samir', 'youssef@gmail.com'),
('Nour Ahmed', 'nour@gmail.com'),
('Khaled Mostafa', 'khaled@gmail.com'),
('Salma Tarek', 'salma@gmail.com'),
('Amr Hany', 'amr@gmail.com');



INSERT INTO Venue (Name, Location, Capacity)
VALUES
('Grand Hall', 'Cairo', 500),
('Tech Center', 'Alexandria', 300),
('Royal Palace', 'Giza', 800),
('Business Hub', 'New Cairo', 200),
('Conference Arena', 'Mansoura', 600),
('Sky Lounge', 'Cairo', 150),
('Innovation Center', 'Alexandria', 400),
('University Hall', 'Minya', 1000),
('Expo Center', 'Giza', 1200),
('Green Garden', 'Luxor', 250);



INSERT INTO Event (Title, OrganizerId, VenueId, EventDate)
VALUES
('Tech Conference 2026', 1, 1, '2026-11-10'),
('AI Workshop', 2, 2, '2026-11-15'),
('Business Summit', 3, 3, '2026-11-20'),
('Startup Meetup', 4, 4, '2026-11-25'),
('Programming Bootcamp', 5, 5, '2026-12-01'),
('Digital Marketing Event', 6, 6, '2026-12-05'),
('Cyber Security Seminar', 7, 7, '2026-12-10'),
('University Tech Day', 8, 8, '2026-12-15'),
('Innovation Expo', 9, 9, '2026-12-20'),
('Music Festival', 10, 10, '2026-12-25');


INSERT INTO Attendee (Name, Email)
VALUES
('Ali Hassan', 'ali@gmail.com'),
('Mona Ahmed', 'mona@gmail.com'),
('Omar Samir', 'omar.attendee@gmail.com'),
('Yara Mohamed', 'yara@gmail.com'),
('Mostafa Khaled', 'mostafa@gmail.com'),
('Hana Adel', 'hana@gmail.com'),
('Karim Tarek', 'karim@gmail.com'),
('Laila Amr', 'laila@gmail.com'),
('Ziad Mahmoud', 'ziad@gmail.com'),
('Farida Nabil', 'farida@gmail.com');



INSERT INTO Ticket (EventId, AttendeeId, Price, CheckedIn)
VALUES
(1, 1, 250.00, '2026-11-10'),
(1, 2, 250.00, '2026-11-10'),
(2, 3, 150.00, '2026-11-15'),
(2, 4, 150.00, '2026-11-15'),
(3, 5, 300.00, '2026-11-20'),
(4, 6, 100.00, '2026-11-25'),
(5, 7, 200.00, '2026-12-01'),
(6, 8, 180.00, '2026-12-05'),
(7, 9, 220.00, '2026-12-10'),
(8, 10, 120.00, '2026-12-15');