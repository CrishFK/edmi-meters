CREATE DATABASE EDMIMETERSDB;

USE EDMIMETERSDB;

CREATE TABLE ElectricMeter
(
    Id INT PRIMARY KEY NOT NULL,
    Serial INT NOT NULL,
    FirmwareVersion NVARCHAR(50),
    State NVARCHAR(50)
);

CREATE TABLE WaterMeter
(
    Id INT PRIMARY KEY NOT NULL,
    Serial INT NOT NULL,
    FirmwareVersion NVARCHAR(50),
    State NVARCHAR(50)
);

CREATE TABLE Gateways
(
    Id INT PRIMARY KEY NOT NULL,
    Serial INT NOT NULL,
    FirmwareVersion NVARCHAR(50),
    State NVARCHAR(50), 
    Ip NVARCHAR(50),
    Port INT
);