CREATE TABLE "LendBook"(
    "ID" INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    "BookID" INT NOT NULL,
    "LendTo" INT NOT NULL,
    "LendBy" INT NOT NULL,
    "LendOn" TIMESTAMP NOT NULL,
    "ReturnedOn" TIMESTAMP
);