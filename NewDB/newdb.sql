SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

CREATE SCHEMA IF NOT EXISTS `newdb` DEFAULT CHARACTER SET latin1 ;
USE `newdb` ;

-- -----------------------------------------------------
-- Table `newdb`.`CAMP`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `newdb`.`CAMP` (
  `CAMP_ID` DECIMAL(10,0) NOT NULL,
  `LOCATION` VARCHAR(45) NOT NULL,
  `USER_NUMBER` DECIMAL(10,0) NOT NULL,
  PRIMARY KEY (`CAMP_ID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `newdb`.`USER`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `newdb`.`USER` (
  `USER_ID` DECIMAL(5) NOT NULL,
  `RFID` VARCHAR(45) NULL,
  `USERNAME` VARCHAR(45) NOT NULL,
  `PASSWORD` VARCHAR(128) NOT NULL,
  `SALT` VARCHAR(128) NOT NULL,
  `USER_LAST_NAME` VARCHAR(45) NOT NULL,
  `USER_FIRST_NAME` VARCHAR(45) NOT NULL,
  `ADDRESS` VARCHAR(45) NULL,
  `PHONE` DECIMAL(10,0) NULL,
  `BALANCE` DECIMAL(5) NOT NULL,
  `CAMP_ID` DECIMAL(5) NULL,
  `CAMP_CAMP_ID` DECIMAL(10,0) NOT NULL,
  UNIQUE INDEX `USERNAME_UNIQUE` (`USERNAME` ASC),
  UNIQUE INDEX `CAMP_ID_UNIQUE` (`CAMP_ID` ASC),
  UNIQUE INDEX `RFID_UNIQUE` (`RFID` ASC),
  INDEX `fk_USER_CAMP1_idx` (`CAMP_CAMP_ID` ASC),
  PRIMARY KEY (`USER_ID`),
  CONSTRAINT `fk_USER_CAMP1`
    FOREIGN KEY (`CAMP_CAMP_ID`)
    REFERENCES `newdb`.`CAMP` (`CAMP_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `newdb`.`EVENT`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `newdb`.`EVENT` (
  `EVENT_ID` DECIMAL(10,0) NOT NULL,
  `DECRIBTION` VARCHAR(45) NOT NULL,
  `USER_NUMBER` DECIMAL(10,0) NOT NULL,
  PRIMARY KEY (`EVENT_ID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `newdb`.`REF_PAYMENT_METHODS`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `newdb`.`REF_PAYMENT_METHODS` (
  `REF_PAYMENT_METHODS_ID` DECIMAL(10,0) NOT NULL,
  PRIMARY KEY (`REF_PAYMENT_METHODS_ID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `newdb`.`SHOP`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `newdb`.`SHOP` (
  `SHOP_ID` DECIMAL(10,0) NOT NULL,
  `SHOP_NAME` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`SHOP_ID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `newdb`.`ORDER`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `newdb`.`ORDER` (
  `ORDER_ID` DECIMAL(10,0) NOT NULL,
  `ORDER_DATE_TIME` DATETIME NULL,
  `USER_USER_ID` DECIMAL(5) NOT NULL,
  `SHOP_PRODUCT_SHOP_ID` DECIMAL(10,0) NOT NULL,
  `SHOP_SHOP_ID` DECIMAL(10,0) NOT NULL,
  PRIMARY KEY (`ORDER_ID`),
  INDEX `fk_ORDER_USER1_idx` (`USER_USER_ID` ASC),
  INDEX `fk_ORDER_SHOP1_idx` (`SHOP_SHOP_ID` ASC),
  CONSTRAINT `fk_ORDER_USER1`
    FOREIGN KEY (`USER_USER_ID`)
    REFERENCES `newdb`.`USER` (`USER_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ORDER_SHOP1`
    FOREIGN KEY (`SHOP_SHOP_ID`)
    REFERENCES `newdb`.`SHOP` (`SHOP_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `newdb`.`PRODUCT`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `newdb`.`PRODUCT` (
  `PRODUCT_ID` DECIMAL(10,0) NOT NULL,
  `PRODUCT_NAME` VARCHAR(45) NOT NULL,
  `PRICE` DECIMAL(5) NOT NULL,
  `RENTAL_PRICE` DECIMAL(5) NULL,
  PRIMARY KEY (`PRODUCT_ID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `newdb`.`ORDER_DATAILS`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `newdb`.`ORDER_DATAILS` (
  `PRODUCT_PRODUCT_ID` DECIMAL(10,0) NULL,
  `ORDER_ORDER_ID` DECIMAL(10,0) NULL,
  `QUANTITY` DECIMAL(10,0) NULL,
  `ORDERDETAILSID` VARCHAR(45) NOT NULL,
  INDEX `fk_ORDER_DATAILS_PRODUCT1_idx` (`PRODUCT_PRODUCT_ID` ASC),
  INDEX `fk_ORDER_DATAILS_ORDER1_idx` (`ORDER_ORDER_ID` ASC),
  PRIMARY KEY (`ORDERDETAILSID`),
  CONSTRAINT `fk_ORDER_DATAILS_PRODUCT1`
    FOREIGN KEY (`PRODUCT_PRODUCT_ID`)
    REFERENCES `newdb`.`PRODUCT` (`PRODUCT_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ORDER_DATAILS_ORDER1`
    FOREIGN KEY (`ORDER_ORDER_ID`)
    REFERENCES `newdb`.`ORDER` (`ORDER_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `newdb`.`SHOP_PRODUCT`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `newdb`.`SHOP_PRODUCT` (
  `SHOP_ID` DECIMAL(10,0) NULL,
  `PRODUCT_ID` DECIMAL(10,0) NULL,
  `SHOP_PRODUCT_ID` VARCHAR(45) NOT NULL,
  ` NumberLeft` INT NULL,
  INDEX `PRODUCT_ID_idx` (`PRODUCT_ID` ASC),
  PRIMARY KEY (`SHOP_PRODUCT_ID`),
  CONSTRAINT `SHOP_ID`
    FOREIGN KEY (`SHOP_ID`)
    REFERENCES `newdb`.`SHOP` (`SHOP_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `PRODUCT_ID`
    FOREIGN KEY (`PRODUCT_ID`)
    REFERENCES `newdb`.`PRODUCT` (`PRODUCT_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `newdb`.`CUSTOMER_PAYMENT_METHODS`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `newdb`.`CUSTOMER_PAYMENT_METHODS` (
  `USER_ID` DECIMAL(10,0) NOT NULL,
  `REF_PAYMENT_METHODS_REF_PAYMENT_METHODS_ID` DECIMAL(10,0) NOT NULL,
  INDEX `REF_PAYMENT_METHODS_REF_PAYMENT_METHODS_ID_idx` (`REF_PAYMENT_METHODS_REF_PAYMENT_METHODS_ID` ASC),
  PRIMARY KEY (`USER_ID`, `REF_PAYMENT_METHODS_REF_PAYMENT_METHODS_ID`),
  CONSTRAINT `USER_ID`
    FOREIGN KEY (`USER_ID`)
    REFERENCES `newdb`.`USER` (`USER_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `REF_PAYMENT_METHODS_REF_PAYMENT_METHODS_ID`
    FOREIGN KEY (`REF_PAYMENT_METHODS_REF_PAYMENT_METHODS_ID`)
    REFERENCES `newdb`.`REF_PAYMENT_METHODS` (`REF_PAYMENT_METHODS_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `newdb`.`USER_EVENT`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `newdb`.`USER_EVENT` (
  `USER_USER_ID` DECIMAL(5) NOT NULL,
  `EVENT_EVENT_ID` DECIMAL(10,0) NOT NULL,
  PRIMARY KEY (`USER_USER_ID`, `EVENT_EVENT_ID`),
  INDEX `fk_USER_EVENT_EVENT1_idx` (`EVENT_EVENT_ID` ASC),
  CONSTRAINT `fk_USER_EVENT_USER1`
    FOREIGN KEY (`USER_USER_ID`)
    REFERENCES `newdb`.`USER` (`USER_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_USER_EVENT_EVENT1`
    FOREIGN KEY (`EVENT_EVENT_ID`)
    REFERENCES `newdb`.`EVENT` (`EVENT_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `newdb`.`camp`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `newdb`.`camp` (
  `CAMP_ID` INT NOT NULL,
  `LOCATION` VARCHAR(45) NOT NULL,
  `USERS_NUMBER` INT NOT NULL,
  `MAX_USERS` INT NOT NULL,
  PRIMARY KEY (`CAMP_ID`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `newdb`.`ref_payment_methods`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `newdb`.`ref_payment_methods` (
  `REF_PAYMENT_METHODS_ID` INT NOT NULL,
  PRIMARY KEY (`REF_PAYMENT_METHODS_ID`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `newdb`.`user`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `newdb`.`user` (
  `USER_ID` INT NOT NULL,
  `RFID` VARCHAR(45) NULL DEFAULT NULL,
  `USERNAME` VARCHAR(45) NOT NULL,
  `PASSWORD` VARCHAR(128) NOT NULL,
  `SALT` VARCHAR(128) NOT NULL,
  `USER_LAST_NAME` VARCHAR(45) NOT NULL,
  `USER_FIRST_NAME` VARCHAR(45) NOT NULL,
  `ADDRESS` VARCHAR(45) NULL DEFAULT NULL,
  `PHONE` INT NULL,
  `BALANCE` DECIMAL(7,2) NOT NULL,
  `CAMP_CAMP_ID` INT NULL,
  PRIMARY KEY (`USER_ID`),
  UNIQUE INDEX `USERNAME_UNIQUE` (`USERNAME` ASC),
  UNIQUE INDEX `RFID_UNIQUE` (`RFID` ASC),
  INDEX `fk_USER_CAMP1_idx` (`CAMP_CAMP_ID` ASC),
  CONSTRAINT `fk_USER_CAMP1`
    FOREIGN KEY (`CAMP_CAMP_ID`)
    REFERENCES `newdb`.`camp` (`CAMP_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `newdb`.`customer_payment_methods`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `newdb`.`customer_payment_methods` (
  `USER_ID` INT NOT NULL,
  `REF_PAYMENT_METHODS_REF_PAYMENT_METHODS_ID` INT NOT NULL,
  PRIMARY KEY (`USER_ID`, `REF_PAYMENT_METHODS_REF_PAYMENT_METHODS_ID`),
  INDEX `REF_PAYMENT_METHODS_REF_PAYMENT_METHODS_ID_idx` (`REF_PAYMENT_METHODS_REF_PAYMENT_METHODS_ID` ASC),
  CONSTRAINT `REF_PAYMENT_METHODS_REF_PAYMENT_METHODS_ID`
    FOREIGN KEY (`REF_PAYMENT_METHODS_REF_PAYMENT_METHODS_ID`)
    REFERENCES `newdb`.`ref_payment_methods` (`REF_PAYMENT_METHODS_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `USER_ID`
    FOREIGN KEY (`USER_ID`)
    REFERENCES `newdb`.`user` (`USER_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `newdb`.`event`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `newdb`.`event` (
  `EVENT_ID` INT NOT NULL,
  `EVENT_NAME` VARCHAR(45) NOT NULL,
  `DECRIBTION` VARCHAR(45) NOT NULL,
  `USERS_NUMBER` INT NOT NULL,
  `MAX_USERS` INT NOT NULL,
  `TIME` VARCHAR(45) NOT NULL,
  `LOCATION` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`EVENT_ID`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `newdb`.`shop`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `newdb`.`shop` (
  `SHOP_ID` INT NOT NULL,
  `SHOP_NAME` VARCHAR(45) NOT NULL,
  `DESCRIBTION` VARCHAR(300) NOT NULL,
  PRIMARY KEY (`SHOP_ID`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `newdb`.`order`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `newdb`.`order` (
  `ORDER_ID` INT NOT NULL,
  `USER_USER_ID` INT NOT NULL,
  `SHOP_SHOP_ID` INT NOT NULL,
  `TOTALPRICE` VARCHAR(6) NOT NULL,
  `ORDER_DATE_TIME` VARCHAR(40) NOT NULL,
  PRIMARY KEY (`ORDER_ID`),
  INDEX `fk_ORDER_USER1_idx` (`USER_USER_ID` ASC),
  INDEX `fk_ORDER_SHOP1_idx` (`SHOP_SHOP_ID` ASC),
  CONSTRAINT `fk_ORDER_SHOP1`
    FOREIGN KEY (`SHOP_SHOP_ID`)
    REFERENCES `newdb`.`shop` (`SHOP_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ORDER_USER1`
    FOREIGN KEY (`USER_USER_ID`)
    REFERENCES `newdb`.`user` (`USER_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `newdb`.`product`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `newdb`.`product` (
  `PRODUCT_ID` INT NOT NULL,
  `PRODUCT_NAME` VARCHAR(45) NOT NULL,
  `PRICE` DECIMAL(5,2) NOT NULL,
  `RENTAL_PRICE` DECIMAL(5,2) NULL DEFAULT '0',
  `unit` VARCHAR(10) NOT NULL,
  `desc` VARCHAR(100) NULL DEFAULT 'No desc yet',
  PRIMARY KEY (`PRODUCT_ID`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `newdb`.`order_datails`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `newdb`.`order_datails` (
  `ORDERDETAILSID` INT(11) NOT NULL AUTO_INCREMENT,
  `PRODUCT_PRODUCT_ID` INT NULL DEFAULT NULL,
  `ORDER_ORDER_ID` INT NULL DEFAULT NULL,
  `QUANTITY` INT NULL DEFAULT NULL,
  PRIMARY KEY (`ORDERDETAILSID`),
  INDEX `fk_ORDER_DATAILS_PRODUCT1_idx` (`PRODUCT_PRODUCT_ID` ASC),
  INDEX `fk_ORDER_DATAILS_ORDER1_idx` (`ORDER_ORDER_ID` ASC),
  CONSTRAINT `fk_ORDER_DATAILS_ORDER1`
    FOREIGN KEY (`ORDER_ORDER_ID`)
    REFERENCES `newdb`.`order` (`ORDER_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ORDER_DATAILS_PRODUCT1`
    FOREIGN KEY (`PRODUCT_PRODUCT_ID`)
    REFERENCES `newdb`.`product` (`PRODUCT_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 23
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `newdb`.`shop_product`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `newdb`.`shop_product` (
  `SHOP_PRODUCT_ID` INT(11) NOT NULL AUTO_INCREMENT,
  `SHOP_ID` INT NULL DEFAULT NULL,
  `PRODUCT_ID` INT NULL DEFAULT NULL,
  `NUMBERLEFT` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`SHOP_PRODUCT_ID`),
  INDEX `PRODUCT_ID_idx` (`PRODUCT_ID` ASC),
  INDEX `SHOP_ID` (`SHOP_ID` ASC),
  CONSTRAINT `PRODUCT_ID`
    FOREIGN KEY (`PRODUCT_ID`)
    REFERENCES `newdb`.`product` (`PRODUCT_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `SHOP_ID`
    FOREIGN KEY (`SHOP_ID`)
    REFERENCES `newdb`.`shop` (`SHOP_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 21
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `newdb`.`user_event`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `newdb`.`user_event` (
  `USER_USER_ID` INT NOT NULL,
  `EVENT_EVENT_ID` INT NOT NULL,
  PRIMARY KEY (`USER_USER_ID`, `EVENT_EVENT_ID`),
  INDEX `fk_USER_EVENT_EVENT1_idx` (`EVENT_EVENT_ID` ASC),
  CONSTRAINT `fk_USER_EVENT_EVENT1`
    FOREIGN KEY (`EVENT_EVENT_ID`)
    REFERENCES `newdb`.`event` (`EVENT_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_USER_EVENT_USER1`
    FOREIGN KEY (`USER_USER_ID`)
    REFERENCES `newdb`.`user` (`USER_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
