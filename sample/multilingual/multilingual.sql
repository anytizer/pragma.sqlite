CREATE TABLE "languages" (
	"language_id"	TEXT NOT NULL,
	"language_name_latin"	TEXT NOT NULL,
	"language_name_unicode"	TEXT NOT NULL,
	"language_code"	TEXT NOT NULL,
	"language_icon"	TEXT NOT NULL,
	PRIMARY KEY("language_id")
) WITHOUT ROWID;


CREATE TABLE "phrases" (
	"phrase_id"	TEXT NOT NULL,
	"phrase_section"	TEXT NOT NULL,
	"phrase_index"	TEXT NOT NULL,
	"phrase_default_latin"	TEXT NOT NULL,
	PRIMARY KEY("phrase_id")
) WITHOUT ROWID;


CREATE TABLE "translations" (
	"translation_id"	TEXT NOT NULL,
	"language_id"	TEXT NOT NULL,
	"phrase_id"	TEXT NOT NULL,
	"phrase_translation"	TEXT NOT NULL,
	UNIQUE("language_id","phrase_id"),
	FOREIGN KEY("phrase_id") REFERENCES "phrases"("phrase_id") ON UPDATE CASCADE ON DELETE CASCADE,
	FOREIGN KEY("language_id") REFERENCES "languages"("language_id") ON UPDATE CASCADE ON DELETE CASCADE,
	PRIMARY KEY("translation_id")
) WITHOUT ROWID;