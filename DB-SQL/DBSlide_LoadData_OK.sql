Begin transaction

SET dateformat ymd;

use DBSlideASP

delete from course
delete from professor
delete from student
delete from section
delete from grade

INSERT INTO section VALUES (1010, 'BSc Management', 12);
INSERT INTO section VALUES (1020, 'MSc Management', 9);
INSERT INTO section VALUES (1110, 'BSc Economics', 15);
INSERT INTO section VALUES (1120, 'MSc Economics', 6);
INSERT INTO section VALUES (1310, 'BA Sociology', 23);
INSERT INTO section VALUES (1320, 'MA Sociology', 6);

INSERT INTO professor (professor_name, professor_surname, section_id, professor_office, professor_email, professor_hire_date, professor_wage) VALUES ('zidda', 'pietro', 1020, 402, 'pzidda', '2004-12-11', 1900);
INSERT INTO professor (professor_name, professor_surname, section_id, professor_office, professor_email, professor_hire_date, professor_wage) VALUES ('decrop', 'alain', 1120, 403, 'adecrop', '2003-05-09', 1950);
INSERT INTO professor (professor_name, professor_surname, section_id, professor_office, professor_email, professor_hire_date, professor_wage) VALUES ('giot', 'pierre', 1310, 404, 'pgiot', '2002-12-21', 2100);
INSERT INTO professor (professor_name, professor_surname, section_id, professor_office, professor_email, professor_hire_date, professor_wage) VALUES ('lecourt', 'christelle', 1310, 406, 'clecourt', '2003-05-07', 1750);
INSERT INTO professor (professor_name, professor_surname, section_id, professor_office, professor_email, professor_hire_date, professor_wage) VALUES ('scheppens', 'georges', 1020, 410, 'gscheppens', '1986-10-09', 2450);
INSERT INTO professor (professor_name, professor_surname, section_id, professor_office, professor_email, professor_hire_date, professor_wage) VALUES ('louveaux', 'francois', 1110, 407, 'flouveaux', '1990-05-07', 2200);

-- INSERT INTO course VALUES ('EING2234', 'Derivatives', 3.0, 3);
-- INSERT INTO course VALUES ('ECGE2184', 'Marketing management', 3.5, 2);
-- INSERT INTO course VALUES ('EING2283', 'Marketing engineering', 4.0, 1);
-- INSERT INTO course VALUES ('ECGE2183', 'Financial Management', 4.0, 3);
-- INSERT INTO course VALUES ('EING2383', 'Supply chain management et e-business', 2.5, 5);

INSERT INTO course VALUES ('EG1010', 'Derivatives', 3.0, 3);
INSERT INTO course VALUES ('EG1020', 'Marketing management', 3.5, 2);
INSERT INTO course VALUES ('EG2110', 'Marketing engineering', 4.0, 1);
INSERT INTO course VALUES ('EG2120', 'Financial Management', 4.0, 3);
INSERT INTO course VALUES ('EG2210', 'Supply chain management et e-business', 2.5, 5);

INSERT INTO student (first_name, last_name, birth_date, login, section_id, year_result, course_id) VALUES ('Georges', 'Lucas', '1944-05-17 00:00:00', 'glucas', 1320, 10, 'EG2210');
INSERT INTO student (first_name, last_name, birth_date, login, section_id, year_result, course_id) VALUES ('Clint', 'Eastwood', '1930-05-31 00:00:00', 'ceastwoo', 1010, 4, 'EG2210');
INSERT INTO student (first_name, last_name, birth_date, login, section_id, year_result, course_id) VALUES ('Sean', 'Connery', '1930-08-25 00:00:00', 'sconnery', 1020, 12, 'EG2110');
INSERT INTO student (first_name, last_name, birth_date, login, section_id, year_result, course_id) VALUES ('Robert', 'De Niro', '1943-08-17 00:00:00', 'rde niro', 1110, 3, 'EG2210');
INSERT INTO student (first_name, last_name, birth_date, login, section_id, year_result, course_id) VALUES ('Kevin', 'Bacon', '1958-07-08 00:00:00', 'kbacon', 1120, 16, '0');
INSERT INTO student (first_name, last_name, birth_date, login, section_id, year_result, course_id) VALUES ('Kim', 'Basinger', '1953-12-08 00:00:00', 'kbasinge', 1310, 19, '0');
INSERT INTO student (first_name, last_name, birth_date, login, section_id, year_result, course_id) VALUES ('Johnny', 'Depp', '1963-06-09 00:00:00', 'jdepp', 1110, 11, 'EG2210');
INSERT INTO student (first_name, last_name, birth_date, login, section_id, year_result, course_id) VALUES ('Julia', 'Roberts', '1967-10-28 00:00:00', 'jroberts', 1120, 17, '0');
INSERT INTO student (first_name, last_name, birth_date, login, section_id, year_result, course_id) VALUES ('Natalie', 'Portman', '1981-06-09 00:00:00', 'nportman', 1010, 4, 'EG2210');
INSERT INTO student (first_name, last_name, birth_date, login, section_id, year_result, course_id) VALUES ('Georges', 'Clooney', '1961-05-06 00:00:00', 'gclooney', 1020, 4, 'EG2110');
INSERT INTO student (first_name, last_name, birth_date, login, section_id, year_result, course_id) VALUES ('Andy', 'Garcia', '1956-04-12 00:00:00', 'agarcia', 1110, 19, '0');
INSERT INTO student (first_name, last_name, birth_date, login, section_id, year_result, course_id) VALUES ('Bruce', 'Willis', '1955-03-19 00:00:00', 'bwillis', 1010, 6, 'EG2210');
INSERT INTO student (first_name, last_name, birth_date, login, section_id, year_result, course_id) VALUES ('Tom', 'Cruise', '1962-07-03 00:00:00', 'tcruise', 1020, 4, 'EG2110');
INSERT INTO student (first_name, last_name, birth_date, login, section_id, year_result, course_id) VALUES ('Reese', 'Witherspoon', '1976-03-22 00:00:00', 'rwithers', 1020, 7, 'EG1020');
INSERT INTO student (first_name, last_name, birth_date, login, section_id, year_result, course_id) VALUES ('Sophie', 'Marceau', '1966-11-17 00:00:00', 'smarceau', 1110, 6, '0');
INSERT INTO student (first_name, last_name, birth_date, login, section_id, year_result, course_id) VALUES ('Sarah', 'Michelle Gellar', '1977-04-14 00:00:00', 'smichell', 1020, 7, 'EG2110');
INSERT INTO student (first_name, last_name, birth_date, login, section_id, year_result, course_id) VALUES ('Alyssa', 'Milano', '1972-12-19 00:00:00', 'amilano', 1110, 7, '0');
INSERT INTO student (first_name, last_name, birth_date, login, section_id, year_result, course_id) VALUES ('Jennifer', 'Garner', '1972-04-17 00:00:00', 'jgarner', 1120, 18, '0');
INSERT INTO student (first_name, last_name, birth_date, login, section_id, year_result, course_id) VALUES ('Michael J.', 'Fox', '1969-06-20 00:00:00', 'mfox', 1310, 3, '0');
INSERT INTO student (first_name, last_name, birth_date, login, section_id, year_result, course_id) VALUES ('Tom', 'Hanks', '1956-07-09 00:00:00', 'thanks', 1020, 8, 'EG2110');
INSERT INTO student (first_name, last_name, birth_date, login, section_id, year_result, course_id) VALUES ('David', 'Morse', '1953-10-11 00:00:00', 'dmorse', 1110, 2, '0');
INSERT INTO student (first_name, last_name, birth_date, login, section_id, year_result, course_id) VALUES ('Sandra', 'Bullock', '1964-07-26 00:00:00', 'sbullock', 1010, 2, 'EG1020');
INSERT INTO student (first_name, last_name, birth_date, login, section_id, year_result, course_id) VALUES ('Keanu', 'Reeves', '1964-09-02 00:00:00', 'kreeves', 1020, 10, 'EG2210');
INSERT INTO student (first_name, last_name, birth_date, login, section_id, year_result, course_id) VALUES ('Shannen', 'Doherty', '1971-04-12 00:00:00', 'sdoherty', 1320, 2, 'EG2120');
INSERT INTO student (first_name, last_name, birth_date, login, section_id, year_result, course_id) VALUES ('Halle', 'Berry', '1966-08-14 00:00:00', 'hberry', 1320, 18, 'EG2210');

INSERT INTO grade VALUES ('IG', 0, 7);
INSERT INTO grade VALUES ('I', 8, 9);
INSERT INTO grade VALUES ('F', 10, 11);
INSERT INTO grade VALUES ('S', 12, 13);
INSERT INTO grade VALUES ('B', 14, 15);
INSERT INTO grade VALUES ('TB', 16, 17);
INSERT INTO grade VALUES ('E', 18, 20);

commit