CREATE TABLE "Book"(
    "ID" INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    "Name" TEXT NOT NULL UNIQUE,
    "CoverImagePath" TEXT,
    "CategoryID" INT NOT NULL,
    "AuthorID" INT NOT NULL,
    "PublisherID" INT NOT NULL,
    "Description" TEXT NOT NULL,
    "IsLend" BOOLEAN NOT NULL,
    "CreateBy" INT NOT NULL,
    "CreateTime" TIMESTAMP NOT NULL
);