USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	email_address varchar(100),
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)

CREATE TABLE collections (
	collection_id int IDENTITY(1,1) NOT NULL,
	collection_name varchar(100) NOT NULL,
	is_public bit NOT NULL,
	user_id int NOT NULL,
	favorites int NOT NULL,
	description varchar(500),
	cover varchar(500),
	theme varchar(100),
	CONSTRAINT PK_collections PRIMARY KEY (collection_id),
	CONSTRAINT FK_collections_users FOREIGN KEY (user_id) REFERENCES users(user_id)
)

CREATE TABLE comics (
	api_detail_url varchar(max),
	cover_date varchar(max) NOT NULL,
	date_added varchar(max),
	date_last_updated varchar(max),
	deck varchar(max),
	description varchar(max),
	has_staff_review bit,
	id int NOT NULL,
	image_thumb_url varchar(max) NOT NULL,
	issue_number varchar(max),
	name varchar(max) NOT NULL,
	site_detail_url varchar(max) NOT NULL,
	store_date varchar(max),
	CONSTRAINT PK_comic PRIMARY KEY (id)
)

CREATE TABLE comic_collection (
	comic_id int NOT NULL,
	collection_id int NOT NULL,
	CONSTRAINT PK_comic_collection PRIMARY KEY (comic_id, collection_id),
	CONSTRAINT FK_comic_collection_comics FOREIGN KEY (comic_id) REFERENCES comics(id),
	CONSTRAINT FK_comic_collection_collections FOREIGN KEY (collection_id) REFERENCES collections(collection_id)
)

CREATE TABLE collection_favorited (
	collection_id int NOT NULL,
	user_id int NOT NULL,
	CONSTRAINT PK_collection_favorited PRIMARY KEY (collection_id, user_id),
	CONSTRAINT FK_collection_favorited_collection FOREIGN KEY (collection_id) REFERENCES collections(collection_id),
	CONSTRAINT FK_collection_favorited_user FOREIGN KEY (user_id) REFERENCES users(user_id)
)

GO

CREATE FUNCTION dbo.count_favorites_event(@collection_num int)
RETURNS INT
AS
BEGIN
	DECLARE @favSum int
	SELECT @favSum = COUNT(user_id) FROM collection_favorited WHERE collection_id = @collection_num
	RETURN @favSum
END
GO

ALTER TABLE collections
ADD number_of_favorites AS dbo.count_favorites_event(collection_id);