USE JobsDB
GO

CREATE TABLE tasks(
  task_id              INT           NOT NULL    IDENTITY    PRIMARY KEY,
  task_name            VARCHAR(100)  NOT NULL,
  task_create_date     DATETIME      NULL,
  task_type            VARCHAR(100)  NULL,
  task_description     VARCHAR(500)  NULL,
  task_is_processed    BIT           NOT NULL DEFAULT 0,
  task_processed_date  DATETIME      NULL
);
GO