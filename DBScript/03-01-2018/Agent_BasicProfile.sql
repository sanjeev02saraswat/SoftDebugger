CREATE TABLE Agent_BasicProfile
(
AgentID Int Foreign Key References Agent_Master(AgentID),
CompanyID VARCHAR(2),
Language VARCHAR(5),
DefaultPage VARCHAR(200),
Address VARCHAR(2),
ProfileImageLink VARCHAR(200),
Country VARCHAR(2),
Phone VARCHAR(12),
IsPhonePrivate bit,
IsAddressPrivate bit
)