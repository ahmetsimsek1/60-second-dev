CREATE FUNCTION util.ConvertFromBase64 (
    @Input NVARCHAR(MAX)
)
RETURNS VARBINARY(MAX)
AS
BEGIN
    -- Note that "value" is case-sensitive (must be lower-case)
    RETURN CAST(@Input AS XML).value('.', 'VARBINARY(MAX)');
END;
GO
