CREATE TABLE `Customer`(
    `C_NIC` INT UNSIGNED NOT NULL AUTO_INCREMENT,
    `C_Name` VARCHAR(255) NOT NULL,
    `C_Tel` INT NOT NULL,
    `C_Email` VARCHAR(255) NOT NULL,
    `C_Address` VARCHAR(255) NOT NULL
);
ALTER TABLE
    `Customer` ADD PRIMARY KEY(`C_NIC`);
CREATE TABLE `VehicleHire`(
    `C_NIC` INT UNSIGNED NOT NULL AUTO_INCREMENT,
    `V_CN` VARCHAR(255) NOT NULL,
    `StartDate` DATE NOT NULL,
    `StartMilage` INT NOT NULL,
    `EtaMilage` INT NOT NULL,
    `EndDate` DATE NOT NULL,
    `ReturnDate` DATE NOT NULL,
    `EndMilage` INT NOT NULL,
    `Rider` TINYINT(1) NOT NULL,
    `R_NIC` INT NULL
);
ALTER TABLE
    `VehicleHire` ADD PRIMARY KEY(`C_NIC`);
ALTER TABLE
    `VehicleHire` ADD PRIMARY KEY(`V_CN`);
CREATE TABLE `Vehicle`(
    `V_CN` VARCHAR(255) NOT NULL,
    `V_PN` VARCHAR(255) NOT NULL,
    `V_Brand` VARCHAR(255) NOT NULL,
    `V_Model` VARCHAR(255) NOT NULL,
    `V_Type` VARCHAR(255) NOT NULL,
    `V_Passengers` INT NOT NULL,
    `V_Condition` VARCHAR(255) NOT NULL,
    `V_ImageFolderPath` VARCHAR(255) NOT NULL,
    `V_State` TINYINT(1) NOT NULL COMMENT 'In use = 1,
Not in use = 0'
);
ALTER TABLE
    `Vehicle` ADD PRIMARY KEY(`V_CN`);
CREATE TABLE `VehileRent`(
    `C_NIC` INT UNSIGNED NOT NULL AUTO_INCREMENT,
    `V_CN` VARCHAR(255) NOT NULL,
    `Package` BIGINT NOT NULL,
    `StartDate` DATE NOT NULL,
    `EndDate` DATE NOT NULL,
    `ReturnDate` DATE NOT NULL
);
ALTER TABLE
    `VehileRent` ADD PRIMARY KEY(`C_NIC`);
ALTER TABLE
    `VehileRent` ADD PRIMARY KEY(`V_CN`);
CREATE TABLE `Rider`(
    `R_NIC` INT UNSIGNED NOT NULL AUTO_INCREMENT,
    `R_LN` VARCHAR(255) NOT NULL,
    `R_Name` VARCHAR(255) NOT NULL,
    `R_Email` VARCHAR(255) NOT NULL,
    `R_Tel` INT NOT NULL,
    `R_Address` VARCHAR(255) NOT NULL,
    `Car` TINYINT(1) NOT NULL,
    `Bike` TINYINT(1) NOT NULL,
    `Van` TINYINT(1) NOT NULL,
    `ThreeWheel` TINYINT(1) NOT NULL,
    `Bus` TINYINT(1) NOT NULL,
    `Lorry` TINYINT(1) NOT NULL,
    `R_State` TINYINT(1) NOT NULL COMMENT 'In service = 1,
Not in service = 0'
);
ALTER TABLE
    `Rider` ADD PRIMARY KEY(`R_NIC`);
ALTER TABLE
    `Rider` ADD PRIMARY KEY(`R_LN`);
CREATE TABLE `Employee`(
    `E_NIC` BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
    `E_UName` BIGINT NOT NULL,
    `E_Password` VARCHAR(255) NOT NULL,
    `E_Name` VARCHAR(255) NOT NULL,
    `E_Tel` INT NOT NULL,
    `E_Email` VARCHAR(255) NOT NULL,
    `Department` VARCHAR(255) NOT NULL,
    `E_Address` VARCHAR(255) NOT NULL
);
ALTER TABLE
    `Employee` ADD PRIMARY KEY(`E_NIC`);
ALTER TABLE
    `VehicleHire` ADD CONSTRAINT `vehiclehire_v_cn_foreign` FOREIGN KEY(`V_CN`) REFERENCES `Vehicle`(`V_CN`);
ALTER TABLE
    `VehicleHire` ADD CONSTRAINT `vehiclehire_c_nic_foreign` FOREIGN KEY(`C_NIC`) REFERENCES `Customer`(`C_NIC`);
ALTER TABLE
    `VehicleHire` ADD CONSTRAINT `vehiclehire_r_nic_foreign` FOREIGN KEY(`R_NIC`) REFERENCES `Rider`(`R_NIC`);
ALTER TABLE
    `VehileRent` ADD CONSTRAINT `vehilerent_v_cn_foreign` FOREIGN KEY(`V_CN`) REFERENCES `Vehicle`(`V_CN`);
ALTER TABLE
    `VehileRent` ADD CONSTRAINT `vehilerent_c_nic_foreign` FOREIGN KEY(`C_NIC`) REFERENCES `Customer`(`C_NIC`);