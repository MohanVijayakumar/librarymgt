CREATE OR REPLACE FUNCTION "GetUsersList"()
RETURNS TABLE
(
    "ID" INT,
    "Name" TEXT,
    "RoleID" SMALLINT,
    "RoleName" TEXT
)
AS
$$
BEGIN
    RETURN QUERY
    SELECT
        t0."ID",
        t0."Name",
        t0."RoleID",
        t1."Name" AS "RoleName"
    FROM
        "User" t0 INNER JOIN
        "UserRole" t1 ON t0."RoleID" = t1."ID";
END;
$$
LANGUAGE plpgsql;
