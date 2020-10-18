CREATE TABLE "BookSettings"(
    "ID" SMALLINT NOT NULL PRIMARY KEY,
    "NameMinLength" SMALLINT NOT NULL,
    "NameMaxLength" SMALLINT NOT NULL,
    "DescriptionMinLength" SMALLINT NOT NULL,
    "DescriptionMaxLength" SMALLINT NOT NULL,
    "CoverImageMaxSizeInBytes" INT NOT NULL,
    "CoverImageAllowedFormats" TEXT NOT NULL
);