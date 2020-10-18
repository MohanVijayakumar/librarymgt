CREATE OR REPLACE FUNCTION "GetUserOutputModelByID"(in_user_id INT)
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
        "UserRole" t1 ON t0."RoleID" = t1."ID"
    WHERE
        t0."ID" = in_user_id;
END;
$$
LANGUAGE plpgsql;
