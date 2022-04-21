INSERT INTO users (username, password_hash, salt, email_address)
VALUES ('BillyBob','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','');

INSERT INTO users (username, password_hash, salt, email_address)
VALUES ('Cindy','Jg45HuwT7PZkfuKTz6IB90CtWY5=','LHxP4Xh7bO0=','');

INSERT INTO users (username, password_hash, salt, email_address)
VALUES ('Danielle','Jg45HuwT7PZkfuKTz6IB90CtWY6=','LHxP4Xh7bP0=','');

INSERT INTO users (username, password_hash, salt, email_address)
VALUES ('Ethan','Jg45HuwT7PZkfuKTz6IB90CtWY7=','LHxP4Xh7bQ0=','');

INSERT INTO users (username, password_hash, salt, email_address)
VALUES ('Fred','Jg45HuwT7PZkfuKTz6IB90CtWY8=','LHxP4Xh7bR0=','fred@gmail.com');

INSERT INTO users (username, password_hash, salt, email_address)
VALUES ('Georgia','Jg45HuwT7PZkfuKTz6IB90CtWY9=','LHxP4Xh7bS0=','georgia@gmail.com');

INSERT INTO users (username, password_hash, salt, email_address)
VALUES ('Helen','Jg45HuwT7PZkfuKTz6IB90CtWY0=','LHxP4Xh7bT0=','helen@gmail.com');

INSERT INTO users (username, password_hash, salt, email_address)
VALUES ('Isaac','Jg45HuwT7PZkfuKTz6IB90CtWY1=','LHxP4Xh7bU0=','isaac@gmail.com');



INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Bills Favorite Comics', 1, (SELECT u.user_id FROM users u WHERE username = 'BillyBob'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Bills Scary Comics', 1, (SELECT u.user_id FROM users u WHERE username = 'BillyBob'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Bills Private Comics', 0, (SELECT u.user_id FROM users u WHERE username = 'BillyBob'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Bills Japanese Comics', 1, (SELECT u.user_id FROM users u WHERE username = 'BillyBob'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Bills Limited Editions', 1, (SELECT u.user_id FROM users u WHERE username = 'BillyBob'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Bills Classics', 1, (SELECT u.user_id FROM users u WHERE username = 'BillyBob'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Cindys Favorite Comics', 1, (SELECT u.user_id FROM users u WHERE username = 'Cindy'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Cindys Scary Comics', 1, (SELECT u.user_id FROM users u WHERE username = 'Cindy'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Cindys Private Comics', 0, (SELECT u.user_id FROM users u WHERE username = 'Cindy'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Cindys Japanese Comics', 1, (SELECT u.user_id FROM users u WHERE username = 'Cindy'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Cindy Limited Editions', 1, (SELECT u.user_id FROM users u WHERE username = 'Cindy'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Cindys Classics', 1, (SELECT u.user_id FROM users u WHERE username = 'Cindy'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Danielles Favorite Comics', 1, (SELECT u.user_id FROM users u WHERE username = 'Danielle'), 0 )

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Danielles Scary Comics', 1, (SELECT u.user_id FROM users u WHERE username = 'Danielle'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Danielles Private Comics', 0, (SELECT u.user_id FROM users u WHERE username = 'Danielle'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Danielles Japanese Comics', 1, (SELECT u.user_id FROM users u WHERE username = 'Danielle'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Danielles Limited Editions', 1, (SELECT u.user_id FROM users u WHERE username = 'Danielle'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Danielles Classics', 1, (SELECT u.user_id FROM users u WHERE username = 'Danielle'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Ethans Favorite Comics', 1, (SELECT u.user_id FROM users u WHERE username = 'Ethan'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Ethans Scary Comics', 1, (SELECT u.user_id FROM users u WHERE username = 'Ethan'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Ethans Private Comics', 0, (SELECT u.user_id FROM users u WHERE username = 'Ethan'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Ethans Japanese Comics', 1, (SELECT u.user_id FROM users u WHERE username = 'Ethan'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Ethans Limited Editions', 1, (SELECT u.user_id FROM users u WHERE username = 'Ethan'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Ethans Classics', 1, (SELECT u.user_id FROM users u WHERE username = 'Ethan'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Freds Favorite Comics', 1, (SELECT u.user_id FROM users u WHERE username = 'Fred'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Freds Scary Comics', 1, (SELECT u.user_id FROM users u WHERE username = 'Fred'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Freds Private Comics', 0, (SELECT u.user_id FROM users u WHERE username = 'Fred'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Freds Japanese Comics', 1, (SELECT u.user_id FROM users u WHERE username = 'Fred'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Freds Limited Editions', 1, (SELECT u.user_id FROM users u WHERE username = 'Fred'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Freds Classics', 1, (SELECT u.user_id FROM users u WHERE username = 'Fred'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Georgias Favorite Comics', 1, (SELECT u.user_id FROM users u WHERE username = 'Georgia'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Georgias Scary Comics', 1, (SELECT u.user_id FROM users u WHERE username = 'Georgia'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Georgias Private Comics', 0, (SELECT u.user_id FROM users u WHERE username = 'Georgia'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Georgias Japanese Comics', 1, (SELECT u.user_id FROM users u WHERE username = 'Georgia'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Georgias Limited Editions', 1, (SELECT u.user_id FROM users u WHERE username = 'Georgia'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Georgias Classics', 1, (SELECT u.user_id FROM users u WHERE username = 'Georgia'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Helens Favorite Comics', 1, (SELECT u.user_id FROM users u WHERE username = 'Helen'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Helens Scary Comics', 1, (SELECT u.user_id FROM users u WHERE username = 'Helen'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Helens Private Comics', 0, (SELECT u.user_id FROM users u WHERE username = 'Helen'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Helens Japanese Comics', 1, (SELECT u.user_id FROM users u WHERE username = 'Helen'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Helens Limited Editions', 1, (SELECT u.user_id FROM users u WHERE username = 'Helen'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Helens Classics', 1, (SELECT u.user_id FROM users u WHERE username = 'Helen'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Isaacs Favorite Comics', 1, (SELECT u.user_id FROM users u WHERE username = 'Isaac'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Isaacs Scary Comics', 1, (SELECT u.user_id FROM users u WHERE username = 'Isaac'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Isaacs Private Comics', 0, (SELECT u.user_id FROM users u WHERE username = 'Isaac'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Isaacs Japanese Comics', 1, (SELECT u.user_id FROM users u WHERE username = 'Isaac'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Isaacs Limited Editions', 1, (SELECT u.user_id FROM users u WHERE username = 'Isaac'), 0)

INSERT INTO collections (collection_name, is_public, user_id, favorites)
VALUES ('Isaacs Classics', 1, (SELECT u.user_id FROM users u WHERE username = 'Isaac'), 0)

INSERT INTO comics (api_detail_url,	cover_date,	date_added,	date_last_updated, deck, description, has_staff_review, id, image_thumb_url, issue_number, name, site_detail_url, store_date)
VALUES ('test', '1-1-01', '1-1-01', '1-1-01', 2, 'desc', 1, 2, 'ye.com', 4, 'tester', 'detail.com', '1-1-01')

/*INSERT INTO comics (comicvine_issue_id, comic_name, cover_art_url, publish_date, wiki_page_url)
VALUES (1, 'The Lost Race', 'https://comicvine.gamespot.com/a/uploads/scale_medium/5/58993/2645776-chamber_of_chills__13_cgc_8.5.jpg', '1952-10-01', 'https://comicvine.gamespot.com/chamber-of-chills-magazine-13-the-lost-race/4000-6/')

INSERT INTO comics (comicvine_issue_id, comic_name, cover_art_url, publish_date, wiki_page_url)
VALUES (7, 'Fighting Fronts!', ' https://comicvine.gamespot.com/a/uploads/scale_medium/0/4/8-1488-7-1-fighting-fronts-.jpg', '2008-06-06', 'https://comicvine.gamespot.com/fighting-fronts-3/4000-7/')

INSERT INTO comics (comicvine_issue_id, comic_name, cover_art_url, publish_date, wiki_page_url)
VALUES (8, 'Tomb of Terror', 'https://comicvine.gamespot.com/a/uploads/scale_medium/0/4/9-1489-8-1-tomb-of-terror.jpg', '1952-10-31', 'https://comicvine.gamespot.com/tomb-of-terror-5/4000-8/')

INSERT INTO comics (comicvine_issue_id, comic_name, cover_art_url, publish_date, wiki_page_url)
VALUES (9, 'Witches Tales', 'https://comicvine.gamespot.com/a/uploads/scale_medium/0/4/10-1418-9-1-witches-tales.jpg', '1952-10-01', 'https://comicvine.gamespot.com/witches-tales/4050-1418/')

INSERT INTO comics (comicvine_issue_id, comic_name, cover_art_url, publish_date, wiki_page_url)
VALUES (10, 'Airboy Comics', 'https://comicvine.gamespot.com/a/uploads/scale_medium/0/4/11-1069-10-1-airboy-comics.jpg', '1950-03-01', 'https://comicvine.gamespot.com/airboy-comics-73/4000-10/')

INSERT INTO comics (comicvine_issue_id, comic_name, cover_art_url, publish_date, wiki_page_url)
VALUES (11, 'Black Diamond Western', 'https://comicvine.gamespot.com/a/uploads/scale_medium/0/4/12-1253-11-1-black-diamond-wester.jpg', '1952-10-01', 'https://comicvine.gamespot.com/black-diamond-western/4050-1253/')

INSERT INTO comics (comicvine_issue_id, comic_name, cover_art_url, publish_date, wiki_page_url)
VALUES (12, 'Boy Comics', 'https://comicvine.gamespot.com/a/uploads/scale_medium/0/4/13-942-12-1-boy-comics.jpg', '1952-10-01','https://comicvine.gamespot.com/boy-comics/4050-942/')

INSERT INTO comics (comicvine_issue_id, comic_name, cover_art_url, publish_date, wiki_page_url)
VALUES (13, 'Best of the West', 'https://comicvine.gamespot.com/a/uploads/scale_medium/0/4/14-1441-13-1-best-of-the-west.jpg', '1952-10-01', 'https://comicvine.gamespot.com/best-of-the-west/4050-1441/')

INSERT INTO comics (comicvine_issue_id, comic_name, cover_art_url, publish_date, wiki_page_url)
VALUES (15, 'Tim Holt', 'https://comicvine.gamespot.com/a/uploads/scale_medium/0/4/16-1223-15-1-tim-holt.jpg', '2008-06-06', 'https://comicvine.gamespot.com/tim-holt/4050-1223/')

INSERT INTO comics (comicvine_issue_id, comic_name, cover_art_url, publish_date, wiki_page_url)
VALUES (16, 'Journey Into Mystery', 'https://comicvine.gamespot.com/a/uploads/scale_medium/0/4/17-1497-16-1-journey-into-mystery.jpg', '1952-10-31', 'https://comicvine.gamespot.com/journey-into-mystery/4050-1497/')
*/

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (1, 1)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (8, 1)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (9, 1)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (10, 1)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (11, 1)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (12, 1)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (13, 3)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (14, 3)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (15, 3)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (16, 3)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (1, 2)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (1, 4)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (1, 5)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (1, 6)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (1, 7)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (1, 8)


INSERT INTO comic_collection (comic_id, collection_id)
VALUES (1, 9)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (1, 11)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (1, 12)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (1, 13)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (1, 14)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (1, 15)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (1, 16)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (1, 18)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (1, 19)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (1, 20)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (1, 21)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (1, 22)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (1, 23)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (1, 25)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (1, 26)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (1, 27)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (1, 28)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (1, 29)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (1, 30)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (1, 32)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (1, 33)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (1, 34)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (1, 35)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (1, 36)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (7, 1)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (7, 2)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (7, 4)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (7, 5)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (7, 6)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (7, 7)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (7, 8)


INSERT INTO comic_collection (comic_id, collection_id)
VALUES (7, 9)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (7, 11)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (7, 12)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (7, 13)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (7, 14)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (7, 15)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (7, 16)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (7, 18)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (7, 19)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (7, 20)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (7, 21)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (7, 22)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (7, 23)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (7, 25)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (7, 26)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (7, 27)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (7, 28)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (7, 29)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (7, 30)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (7, 32)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (7, 33)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (7, 34)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (7, 35)

INSERT INTO comic_collection (comic_id, collection_id)
VALUES (7, 36)

INSERT INTO collection_favorited (collection_id, user_id)
VALUES (9, 1)

UPDATE collections
SET favorites += 1
WHERE collection_id = 9

INSERT INTO collection_favorited (collection_id, user_id)
VALUES (11, 1)

UPDATE collections
SET favorites += 1
WHERE collection_id = 11

INSERT INTO collection_favorited (collection_id, user_id)
VALUES (13, 1)

UPDATE collections
SET favorites += 1
WHERE collection_id = 13

INSERT INTO collection_favorited (collection_id, user_id)
VALUES (18, 1)

UPDATE collections
SET favorites += 1
WHERE collection_id = 18

INSERT INTO collection_favorited (collection_id, user_id)
VALUES (23, 1)

UPDATE collections
SET favorites += 1
WHERE collection_id = 23

INSERT INTO collection_favorited (collection_id, user_id)
VALUES (1, 2)

UPDATE collections
SET favorites += 1
WHERE collection_id = 1

INSERT INTO collection_favorited (collection_id, user_id)
VALUES (2, 2)

UPDATE collections
SET favorites += 1
WHERE collection_id = 2

INSERT INTO collection_favorited (collection_id, user_id)
VALUES (4, 2)

UPDATE collections
SET favorites += 1
WHERE collection_id = 4

INSERT INTO collection_favorited (collection_id, user_id)
VALUES (5, 2)

UPDATE collections
SET favorites += 1
WHERE collection_id = 5

INSERT INTO collection_favorited (collection_id, user_id)
VALUES (1, 3)

UPDATE collections
SET favorites += 1
WHERE collection_id = 1

INSERT INTO collection_favorited (collection_id, user_id)
VALUES (2, 3)

UPDATE collections
SET favorites += 1
WHERE collection_id = 2

INSERT INTO collection_favorited (collection_id, user_id)
VALUES (4, 3)

UPDATE collections
SET favorites += 1
WHERE collection_id = 4

INSERT INTO collection_favorited (collection_id, user_id)
VALUES (5, 3)

UPDATE collections
SET favorites += 1
WHERE collection_id = 5

SELECT *
FROM collections

SELECT *
FROM collection_favorited





