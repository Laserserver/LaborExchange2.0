
-- Основная таблица
DROP TABLE IF EXISTS dbo.Company;
-- Вакансия
DROP TABLE IF EXISTS dbo.Vacancy;
-- Размер компании
DROP TABLE IF EXISTS dbo.CompanySize;
-- Тип компании
DROP TABLE IF EXISTS dbo.CompanyType;
-- Логин для захода
DROP TABLE IF EXISTS dbo.[Login];


create table [Login] (
	ID int primary key identity (1,1),
		-- Уникальность очевидна
	Username varchar(50) not null unique,
		-- На пароли пофиг
	Pass varchar(100) not null,
);
	-- Хэш для Pa$$w0rd
insert into [Login] values ('admin', 'SVNNdktYcFhwYWREaVVvTzpzIdnCQZ4ak4ACsEVFSpf7m/B/');


create table CompanyType (
	ID int primary key identity (1,1),
	[Type] varchar(15) not null,
);

insert into CompanyType values ('ООО');
insert into CompanyType values ('АО');
insert into CompanyType values ('ПАО');
insert into CompanyType values ('УП');
insert into CompanyType values ('ТОО');
insert into CompanyType values ('Неком. орг.');
insert into CompanyType values ('Общ. орг.');
insert into CompanyType values ('Фонд');
insert into CompanyType values ('Гос. копр.');
insert into CompanyType values ('ИП');
insert into CompanyType values ('ОАО');
insert into CompanyType values ('ЗАО');
insert into CompanyType values ('Другое');


create table CompanySize (
	ID int primary key identity (1,1),
	[Size] varchar(30) not null,
);
insert into CompanySize values ('Менее 50 сотрудников');
insert into CompanySize values ('От 51 до 100 сотрудников');
insert into CompanySize values ('От 101 до 250 сотрудников');
insert into CompanySize values ('От 251 до 500 сотрудников');
insert into CompanySize values ('Более 500 сотрудников');


create table Company (
	ID int primary key identity (1,1),
	LoginID int not null,
	constraint FK_Company_Logins foreign key (LoginID) references [Login] (ID)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
		-- Эт название
	ShowName varchar(50) not null unique,
		-- Тип компании
	CompanyTypeID int not null,
	constraint FK_Company_CompanyType foreign key (CompanyTypeID) references CompanyType (ID)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
		-- Размер компании
	CompanySizeID int not null,
	constraint FK_Company_CompanySize foreign key (CompanySizeID) references CompanySize (ID)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
		-- Город-то тоже надо указать
	City varchar(30) not null,
	ContactEmail varchar(50) not null,
	ContactPhone varchar(15) not null,
);

	-- Пофиг, будут одинаковы
create table Vacancy (
	ID int primary key identity (1,1),
	CompanyID int not null,
	constraint FK_Vacancy_Company foreign key (CompanyID) references Company (ID)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
	Title varchar(100) not null,
	[Description] varchar(max) not null
);