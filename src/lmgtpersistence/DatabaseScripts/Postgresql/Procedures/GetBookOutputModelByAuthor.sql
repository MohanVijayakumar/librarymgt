CREATE OR REPLACE FUNCTION "GetBookOutputModelByAuthor"(in_author_id INT)
RETURNS TABLE
(
    "ID" INT,
    "Name" TEXT,
    "Description" TEXT,
    "AuthorName" TEXT,
    "AuthorID" INT,
    "PublisherName" TEXT,
    "PublisherID" INT,
    "CategoryName" TEXT,
    "CategoryID" INT,
    "CoverImagePublicPath" TEXT,
    "IsLend" BOOLEAN
)
AS
$$
BEGIN
    RETURN QUERY
    SELECT
        t0."ID",
        t0."Name",
        t0."Description",
        t1."Name" AS "AuthorName",
        t0."AuthorID",
        t3."Name" AS "PublisherName",
        t0."PublisherID",
        t2."Name" AS "CategoryName",
        t0."CategoryID",
        t0."CoverImagePath" AS "CoverImagePublicPath",
        t0."IsLend"
    FROM
        "Book" t0 INNER JOIN
        "Author" t1 ON t0."AuthorID" = t1."ID" INNER JOIN
        "BookCategory" t2 ON t0."CategoryID" = t2."ID" INNER JOIN
        "Publisher" t3 ON t0."PublisherID" = t3."ID"
    WHERE
        t0."AuthorID" = in_author_id;
    
END;
$$
LANGUAGE plpgsql;
