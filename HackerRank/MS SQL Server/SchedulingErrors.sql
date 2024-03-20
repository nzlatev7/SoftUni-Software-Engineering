select * from PROFESSOR p
inner join schedule s on p.ID = s.professor_id
inner join course c on c.id = s.course_id
where c.department_id <> p.DEPARTMENT_ID

--select * from schedule s
--join PROFESSOR p on p.ID = s.professor_id
--join DEPARTMENT d on d.ID = p.DEPARTMENT_ID
--join course c on c.department_id = d.ID

--select p.NAME, c.name from PROFESSOR p
--inner join schedule s on p.ID = s.professor_id
--inner join course c on c.id = s.course_id
--where c.department_id <> p.DEPARTMENT_ID

--SELECT DISTINCT prof.name AS "PROFESSOR.NAME", cou.name AS "COURSE.NAME"
--FROM professor prof
--INNER JOIN schedule sch 
--ON sch.professor_id = prof.id
--INNER JOIN course cou 
--ON sch.course_id = cou.id
--WHERE cou.department_id <> prof.department_id;