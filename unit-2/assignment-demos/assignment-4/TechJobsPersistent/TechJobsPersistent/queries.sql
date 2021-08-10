--Part 1
Employers.Id = int | Employers.Location = longtext | Employers.Name = longtext

Jobs.EmployerId = int | Jobs.Id = int | Jobs.Name = longtext

JobSkills.JobId = int | JobSkills.SkillId = int

Skills.Description = longtext | Skills.Id = int | Skills.Name = longtext
--Part 2
SELECT Name FROM Employers WHERE Location = "St. Louis City";

--Part 3
SELECT * FROM Skills
      LEFT JOIN JobSkills ON Skills.Id = JobSkills.SkillId
      WHERE JobSkills.JobId IS NOT NULL
      ORDER BY name ASC;