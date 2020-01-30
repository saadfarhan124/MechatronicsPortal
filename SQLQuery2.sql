ALTER TABLE PersonalInformation
ADD CONSTRAINT FK_Alumni_Users
FOREIGN KEY (alumni_id) REFERENCES AlumniUsersAuthenticate(alumni_id)