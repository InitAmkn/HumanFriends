-- Active: 1695750263333@@localhost@5432@Animal_db

DROP TABLE Animals;
CREATE TABLE Animals (
    ID int PRIMARY KEY NOT NULL AUTO_INCREMENT,
    Name varchar(255),
    Birthday DATE,
    IDTypeAnimal int,
    FOREIGN KEY (IDTypeAnimal)  REFERENCES TypesAnimal (ID)
);

DROP TABLE TypesAnimal;

CREATE TABLE TypesAnimal (
    ID int PRIMARY KEY NOT NULL AUTO_INCREMENT,
    Name varchar(255),
    IDApplicability int,
    FOREIGN KEY (IDApplicability)  REFERENCES Applicability (ID)
);

CREATE TABLE Applicability (
    ID int PRIMARY KEY NOT NULL AUTO_INCREMENT,
    Name varchar(255)
);

CREATE TABLE Commands (
    ID int PRIMARY KEY NOT NULL AUTO_INCREMENT,
    Name varchar(255)
);

CREATE TABLE ApplicabilityCommands (
    ID int PRIMARY KEY NOT NULL AUTO_INCREMENT,
    IDAnimal INT,
    IDCommand INT,
    FOREIGN KEY (IDAnimal) REFERENCES Animals (ID),
    FOREIGN KEY (IDCommand) REFERENCES Commands (ID)
);

INSERT INTO ApplicabilityAnimal ( Name )
VALUES 
    ('Вьючное'),
    ('Домашнее');


INSERT INTO TypesAnimal (Name, ApplicabilityAnimalID)
VALUES 
    ('Верблюд',1),
    ('Собаки',2),
    ('Кошки',2),
    ('Хомяки',2),
    ('Лошади',1),
    ('Ослы',1);


SELECT TypesAnimal.Name , Applicability.Name 
FROM TypesAnimal
LEFT JOIN Applicability ON TypesAnimal.IDApplicability = Applicability.ID ;

INSERT INTO "Animal" (
     "Name",
     "Birthday",
     "TypeAnimalID")
VALUES 
    ('Арлет', '1993-05-17', 1),
    ('Квинта', '2020-09-13', 2),
    ('Волли', '2001-12-16', 2),
    ('Ерта', '2022-02-27', 3),
    ('Бимки', '1999-07-18', 3),
    ('Солли', '2023-07-17', 4),
    ('Никита', '2008-02-02', 4),
    ('Мутан', '1998-11-23', 5),
    ('Улье', '1992-04-12', 5),
    ('Гастор', '2021-02-13',6),
    ('Буран', '2013-10-02', 6)
;

SELECT Animals.Name, Animals.Birthday, TypesAnimal.Name 
FROM Animals 
LEFT JOIN TypesAnimal 
ON 
Animals.TypeAnimalID = TypesAnimal.ID;

INSERT INTO "Command" ("Name")
VALUES 
('Лежать'),
('Ко мне'),
('Фу'),
('Голос'),
('Тихо'),
('Апорт'),
('Сидеть'),
('Стой'),
('Вперед'),
('Рысь'),
('Хоп'),
('Шагом'),
('Тише');


INSERT INTO "ApplicabilityCommand" ("AnimalID", "CommandID")
VALUES
(3,1),(3,2),(3,3),(3,4),(3,5),(3,6),(3,7),(3,8),
(4,5),(4,6),(4,7),(4,8),
(9,8),(9,9),(9,10),(9,11),(9,12),(9,13);

DELETE FROM 
Animals
WHERE Animals.IDTypeAnimal = 1;

CREATE TABLE YoungAnimals 
SELECT *, 
CONCAT(TIMESTAMPDIFF(YEAR, Birthday, CURRENT_DATE()),' лет ',
TIMESTAMPDIFF(MONTH, Birthday, CURRENT_DATE())%12, ' мес.') AS Age
FROM Animals
WHERE TIMESTAMPDIFF(YEAR, Birthday, CURRENT_DATE()) BETWEEN 1 AND 2;

INSERT TypesAnimal (Name, IDApplicability)
VALUES 
    ('Копытные',1);

DELETE FROM 
TypesAnimal
WHERE TypesAnimal.ID = 5;
DELETE FROM 
TypesAnimal
WHERE TypesAnimal.ID = 6;

UPDATE Animals 
SET Animals.IDTypeAnimal = 7
WHERE
Animals.IDTypeAnimal = 5
OR
Animals.IDTypeAnimal = 6;


CREATE TABLE UnionTable
SELECT 
    Animals.Name,
    Animals.Birthday,
    TypesAnimal.Name AS Type,
    ApplicabilityAnimals.Name AS Applicability,
    GROUP_CONCAT(' ', Commands.Name) AS Commands
FROM Animals
    LEFT JOIN TypesAnimal
    ON Animals.IDTypeAnimal = TypesAnimal.ID
    LEFT JOIN ApplicabilityAnimals
    ON TypesAnimal.IDApplicability = ApplicabilityAnimals.ID
    LEFT JOIN ApplicabilityCommands
    ON Animals.ID = ApplicabilityCommands.IDAnimal
    LEFT JOIN Commands
    ON Commands.ID = ApplicabilityCommands.IDCommand
GROUP BY(Animals.ID)
