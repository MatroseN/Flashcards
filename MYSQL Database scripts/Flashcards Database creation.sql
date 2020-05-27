drop database if exists flashcards;
create database flashcards;
use flashcards;

create table userAccount(
	iD  nvarchar(40)not null,
    primary key(iD)
)Engine=Innodb;

create table flashcardCategory(
	categoryCode int auto_increment not null,
    categoryName nvarchar(25) not null,
    userAccountId nvarchar(40) not null,
    foreign Key(userAccountId) references userAccount(iD),
    primary key(categoryCode)
)Engine=Innodb;

create table flashcard(
	flashcardId int auto_increment not null,
    flashcardName nvarchar(25),
    category int,
    question text not null,
    answer text not null,
    userAccountId nvarchar(40) not null,
    foreign Key(userAccountId) references userAccount(iD),
    foreign key(category) references flashcardCategory(categoryCode),
    primary key(flashcardId)
)Engine=Innodb;