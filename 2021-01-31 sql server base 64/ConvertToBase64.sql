CREATE FUNCTION util.ConvertToBase64 (
    @Input VARBINARY(MAX)
)
RETURNS NVARCHAR(MAX)
AS
BEGIN
    RETURN (
        SELECT @Input
        FOR XML PATH(''), BINARY BASE64
    );
END
GO
