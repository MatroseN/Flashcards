use flashcards;

DELIMITER //
-- Gets the specific users flashcards
drop procedure if exists getAllUserFlashcards//
CREATE PROCEDURE getAllUserFlashcards (in userId nvarchar(250))
BEGIN
		select
			flashcard.*
		from
			flashcard
		where 
			flashcard.userAccountId = userId
		order by
			flashcard.flashcardName;
END;
//

DELIMITER ;

DELIMITER //
-- Gets the specific users flashcards
drop procedure if exists getAllUserFlashcardsOfCategory//
CREATE PROCEDURE getAllUserFlashcardsOfCategory (in userId nvarchar(250), in categoryCode int)
BEGIN
		select
			flashcard.*
		from
			flashcard
		where 
			flashcard.userAccountId = userId and flashcard.category = categoryCode
		order by
			flashcard.flashcardName;
END;
//

DELIMITER ;

DELIMITER //
-- Gets the specific users flashcards
drop function if exists getCategoryCode//
CREATE FUNCTION getCategoryCode (_userId nvarchar(250), _categoryName nvarchar(25))
RETURNS int
READS SQL DATA
DETERMINISTIC
BEGIN
		declare _categoryCode int;
		select
			flashcardCategory.categoryCode
		into
			_categoryCode
       from
			flashcardCategory
		where
			userAccountId = _userId and categoryName = _categoryName;
		return _categoryCode;
            
END;
//

DELIMITER ;

DELIMITER //
-- Checks if specific user already have category with that name
drop function if exists checkCategoryName//
CREATE FUNCTION checkCategoryName(_userId nvarchar(250), _categoryName nvarchar(25))
RETURNS int
READS SQL DATA
DETERMINISTIC
BEGIN
		if(select not exists(select categoryName from flashcardCategory where categoryName = _categoryName and userAccountId = _userId))then
			return 0;
		else
			SIGNAL sqlstate "45000" set message_text ="You  already have a category with that name";
			return 1;
        end if;		
END;
//

DELIMITER ;

DELIMITER //
-- Creates a new flashcard for a user
drop procedure if exists createNewFlashcardCategory//
CREATE PROCEDURE createNewFlashcardCategory (in _userId nvarchar(250), _categoryName nvarchar(25))
BEGIN
		if(select not exists(select iD from userAccount where userAccount.iD = _userId)) then
			insert into userAccount(iD) values (_userId);
            end if;
       if(checkCategoryName(_userId, _categoryName) = 0) then
		
		insert into
			flashcardCategory(categoryName, userAccountId)
        values
			(_categoryName, _userId);
            end if;
	
END;
//

DELIMITER ;

DELIMITER //
-- Creates a new flashcard for a user
drop procedure if exists createNewFlashcard//
CREATE PROCEDURE createNewFlashcard (in _userId nvarchar(250), _category nvarchar(25), _flashcardLabel nvarchar(25), _question text, _answer text)
BEGIN
		if(select not exists(select iD from userAccount where userAccount.iD = _userId)) then
			insert into userAccount(iD) values (_userId);
            end if;	
		insert into
			flashcard(flashcardName, category, question, answer, userAccountId)
		values
			(_flashcardLabel,  _category, _question, _answer, _userId);
END;
//

DELIMITER ;

DELIMITER //
-- Gets the specific users flashcards
drop procedure if exists getAllflashcardCategoriesForUser//
CREATE PROCEDURE getAllflashcardCategoriesForUser (in userId nvarchar(250))
BEGIN
		select
			flashcardCategory.*
		from
			flashcardCategory
		where 
			flashcardCategory.userAccountId = userId
		order by
			flashcardCategory.categoryCode;
END;
//

DELIMITER ;