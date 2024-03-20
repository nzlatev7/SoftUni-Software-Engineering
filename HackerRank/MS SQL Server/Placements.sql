select Name from students s
join friends f on f.ID = s.id
join packages p1 on s.id = p1.id
join packages p2 on f.Friend_ID = p2.id
where p1.Salary < p2.Salary
order by p2.Salary