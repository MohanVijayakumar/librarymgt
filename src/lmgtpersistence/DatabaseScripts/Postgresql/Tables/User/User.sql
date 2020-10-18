CREATE TABLE "User"(
    "ID" INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    "Name" TEXT NOT NULL UNIQUE,
    "Password" TEXT NOT NULL,
    "RoleID" SMALLINT NOT NULL,
    "CreateBy" INT NOT NULL,
    "CreateTime" TIMESTAMP NOT NULL
);