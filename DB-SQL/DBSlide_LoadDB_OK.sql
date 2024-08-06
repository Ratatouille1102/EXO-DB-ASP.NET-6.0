CREATE DATABASE DBSlideASP
GO

USE DBSlideASP
GO

CREATE TABLE section (
  section_id int NOT NULL,
  section_name varchar(50),
  delegate_id int,
  CONSTRAINT PK_section PRIMARY KEY (section_id)
)

CREATE TABLE professor (
  professor_id int NOT NULL IDENTITY,
  professor_name varchar(30) NOT NULL,
  professor_surname varchar(30) NOT NULL,
  section_id int NOT NULL,
  professor_office int NOT NULL,
  professor_email varchar(30) NOT NULL,
  professor_hire_date datetime NOT NULL,
  professor_wage int NOT NULL,
  CONSTRAINT PK_professor PRIMARY KEY (professor_id),
  constraint FK_professor_section foreign key (section_id) references section (section_id)
)

CREATE TABLE course (
  course_id varchar(8) NOT NULL ,
  course_name varchar(200) NOT NULL ,
  course_ects decimal(3,1) NOT NULL,
  professor_id int NOT NULL,
  CONSTRAINT PK_course PRIMARY KEY (course_id),
  constraint FK_course_professor foreign key (professor_id) references professor (professor_id)
)

CREATE TABLE student (
  student_id int NOT NULL IDENTITY,
  first_name varchar(50) NOT NULL,
  last_name varchar(50) NOT NULL,
  birth_date datetime NOT NULL,
  login varchar(50) NOT NULL,
  section_id int NOT NULL,
  year_result int,
  course_id varchar(6) NOT NULL,
  CONSTRAINT PK_student PRIMARY KEY (student_id),
  constraint FK_student_section foreign key (section_id) references section (section_id)
)

CREATE TABLE grade (
  grade char(2) NOT NULL ,
  lower_bound int NOT NULL,
  upper_bound int NOT NULL,
  CONSTRAINT PK_grade PRIMARY KEY (grade)
)

GO