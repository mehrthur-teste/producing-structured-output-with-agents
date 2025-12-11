docker build -t postgres-employee-db .
docker run --name postgres-container -d postgres-employee-db
docker exec -it postgres-container psql -U postgres -d yourdatabase
SELECT * FROM employee;



