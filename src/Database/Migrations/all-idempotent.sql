CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20231107141454_Init') THEN
    CREATE TABLE "Emotions" (
        "Id" uuid NOT NULL,
        "Name" text NOT NULL,
        "IsCoreEmotion" boolean NOT NULL,
        "IsDeleted" boolean NOT NULL,
        CONSTRAINT "PK_Emotions" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20231107141454_Init') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20231107141454_Init', '8.0.0');
    END IF;
END $EF$;
COMMIT;

