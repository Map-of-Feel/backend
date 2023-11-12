FROM postgres:latest as final

# escape=\

COPY Migrations/all-idempotent.sql all-idempotent.sql

# ARG host
# ARG database
# ARG username
# ARG password

# ENV POSTGRES_HOST $host
# ENV POSTGRES_DB $database
# ENV POSTGRES_USER $username
# ENV POSTGRES_PASSWORD $password

ENTRYPOINT bash -c "psql -h $POSTGRES_HOST -d $POSTGRES_DB -U $POSTGRES_USER -f all-idempotent.sql"
