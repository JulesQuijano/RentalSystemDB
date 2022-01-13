CREATE DATABASE  IF NOT EXISTS `rental_db` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `rental_db`;
-- MySQL dump 10.13  Distrib 8.0.27, for Win64 (x86_64)
--
-- Host: localhost    Database: rental_db
-- ------------------------------------------------------
-- Server version	8.0.27

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `contracts`
--

DROP TABLE IF EXISTS `contracts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `contracts` (
  `ContractId` int NOT NULL AUTO_INCREMENT,
  `TenantId` int NOT NULL,
  `UnitId` int NOT NULL,
  `ContractStart` date NOT NULL,
  `ContractEnd` date NOT NULL,
  `ContractDone` tinyint(1) DEFAULT NULL,
  `Comment` longtext,
  PRIMARY KEY (`ContractId`),
  UNIQUE KEY `UNQ_contract_tenant_unit` (`ContractId`,`TenantId`,`UnitId`),
  KEY `TenantId` (`TenantId`),
  KEY `UnitId` (`UnitId`),
  CONSTRAINT `contracts_ibfk_1` FOREIGN KEY (`TenantId`) REFERENCES `tenants` (`TenantId`),
  CONSTRAINT `contracts_ibfk_2` FOREIGN KEY (`UnitId`) REFERENCES `units` (`UnitId`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `payment_type`
--

DROP TABLE IF EXISTS `payment_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `payment_type` (
  `TypeId` int NOT NULL,
  `TypeName` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`TypeId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `payments`
--

DROP TABLE IF EXISTS `payments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `payments` (
  `PaymentId` int NOT NULL AUTO_INCREMENT,
  `ContractId` int DEFAULT NULL,
  `PaymentTypeId` int DEFAULT NULL,
  `PaymentDate` date DEFAULT NULL,
  `ReceiptNo` varchar(50) DEFAULT NULL,
  `PaymentAmount` varchar(100) DEFAULT NULL,
  `PaymentStatus` varchar(20) DEFAULT NULL,
  `Comment` longtext,
  PRIMARY KEY (`PaymentId`),
  UNIQUE KEY `UNQ_Payment_Contract` (`PaymentId`,`ContractId`),
  KEY `ContractId` (`ContractId`),
  KEY `fk_paymentType` (`PaymentTypeId`),
  CONSTRAINT `fk_paymentType` FOREIGN KEY (`PaymentTypeId`) REFERENCES `payment_type` (`TypeId`),
  CONSTRAINT `payments_ibfk_1` FOREIGN KEY (`ContractId`) REFERENCES `contracts` (`ContractId`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tenants`
--

DROP TABLE IF EXISTS `tenants`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tenants` (
  `TenantId` int NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(30) DEFAULT NULL,
  `MiddleName` varchar(30) DEFAULT NULL,
  `LastName` varchar(30) DEFAULT NULL,
  `MobileNo` varchar(45) DEFAULT NULL,
  `EmailAddress` varchar(45) DEFAULT NULL,
  `PermaAddress` varchar(100) DEFAULT NULL,
  `Company` varchar(75) DEFAULT NULL,
  `AnnualIncome` varchar(100) DEFAULT NULL,
  `HouseholdNum` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`TenantId`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `units`
--

DROP TABLE IF EXISTS `units`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `units` (
  `UnitId` int NOT NULL AUTO_INCREMENT,
  `UnitType` varchar(30) DEFAULT NULL,
  `UnitArea` varchar(50) DEFAULT NULL,
  `RentalAmount` varchar(100) DEFAULT NULL,
  `TenantLimit` varchar(10) DEFAULT NULL,
  `UnitStatus` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`UnitId`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping routines for database 'rental_db'
--
/*!50003 DROP PROCEDURE IF EXISTS `Contracts_Get_Data` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Contracts_Get_Data`(
_SearchText VARCHAR(100)
)
BEGIN
	SELECT ContractId AS 'ID', CONCAT(t.FirstName, " ", t.MiddleName, " ", t.LastName) AS 'Full Name', 
		h.UnitType AS 'Unit Type', c.ContractStart AS 'Contract Start', c.ContractEnd AS 'Contract End', 
        c.ContractDone AS 'Contract Done', c.Comment
	FROM contracts AS c INNER JOIN tenants AS t ON c.TenantId = t.TenantId
		Inner JOIN units AS h ON c.UnitId = h.UnitId
	WHERE CONCAT(t.FirstName, " ", t.MiddleName, " ", t.LastName) LIKE CONCAT('%',_SearchText,'%')
		OR h.UnitType LIKE CONCAT('%',_SearchText,'%') OR c.ContractStart LIKE CONCAT('%',_SearchText,'%') 
        OR c.ContractEnd LIKE CONCAT('%',_SearchText,'%') OR c.Comment LIKE CONCAT('%',_SearchText,'%'); 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Contracts_Get_Data_G` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Contracts_Get_Data_G`(
_SearchText VARCHAR(100)
)
BEGIN
	SELECT ContractId AS 'ID', CONCAT(t.FirstName, " ", t.MiddleName, " ", t.LastName) AS 'Full Name', 
		h.UnitType AS 'Unit Type', c.ContractStart AS 'Contract Start', c.ContractEnd AS 'Contract End', 
        c.ContractDone AS 'Contract Done', c.Comment
	FROM contracts AS c INNER JOIN tenants AS t ON c.TenantId = t.TenantId
		Inner JOIN units AS h ON c.UnitId = h.UnitId
	WHERE CONCAT(t.FirstName, " ", t.MiddleName, " ", t.LastName) LIKE CONCAT('%',_SearchText,'%')
		OR h.UnitType LIKE CONCAT('%',_SearchText,'%') OR c.ContractStart LIKE CONCAT('%',_SearchText,'%') 
        OR c.ContractEnd LIKE CONCAT('%',_SearchText,'%') OR c.Comment LIKE CONCAT('%',_SearchText,'%'); 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Contracts_Search_Data_G` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Contracts_Search_Data_G`(
_SearchText VARCHAR(100)
)
BEGIN
	SELECT ContractId AS 'ID', CONCAT(t.FirstName, " ", t.MiddleName, " ", t.LastName) AS 'Full Name', 
		h.UnitType AS 'Unit Type', c.ContractStart AS 'Contract Start', c.ContractEnd AS 'Contract End', 
        c.ContractDone AS 'Contract Done', c.Comment
	FROM contracts AS c INNER JOIN tenants AS t ON c.TenantId = t.TenantId
		Inner JOIN units AS h ON c.UnitId = h.UnitId
	WHERE CONCAT(t.FirstName, " ", t.MiddleName, " ", t.LastName) LIKE CONCAT('%',_SearchText,'%')
		OR h.UnitType LIKE CONCAT('%',_SearchText,'%') OR c.ContractStart LIKE CONCAT('%',_SearchText,'%') 
        OR c.ContractEnd LIKE CONCAT('%',_SearchText,'%') OR c.Comment LIKE CONCAT('%',_SearchText,'%'); 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Contract_Get_Data_V` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Contract_Get_Data_V`(
_ContractId VARCHAR(10)
)
BEGIN
	SELECT CONCAT(t.FirstName, " ", t.MiddleName, " ", t.LastName) AS 'Name', 
		u.UnitType, CONCAT(u.UnitId, " - ", u.UnitType), c.ContractStart, c.ContractEnd, 
        c.Comment, u.UnitId, c.ContractDone
	FROM contracts AS c INNER JOIN tenants AS t ON c.TenantId = t.TenantId 
    INNER JOIN units AS u ON c.UnitId = u.UnitId 
    WHERE c.ContractId = _ContractId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Contract_New` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Contract_New`(
_TenantId INT,
_UnitId INT,
_ContractStart DATE,
_ContractEnd DATE,
_Comment LONGTEXT
)
BEGIN
	INSERT INTO contracts(TenantId, UnitId, ContractStart, ContractEnd, ContractDone, Comment)
    VALUES (_TenantId, _UnitId, _ContractStart, _ContractEnd, 0, _Comment);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Contract_Update` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Contract_Update`(
_ContractId INT,
_UnitId INT,
_ContractStart DATE,
_ContractEnd DATE,
_ContractDone TINYINT,
_Comment LONGTEXT
)
BEGIN
	UPDATE contracts
    SET
        UnitId = _UnitId,
        ContractStart = _ContractStart,
        ContractEnd = _ContractEnd,
        ContractDone = _ContractDone,
        Comment = _Comment
	WHERE ContractId = _ContractId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Payment_Delete` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Payment_Delete`(
_PaymentId INT
)
BEGIN
	DELETE FROM payments WHERE PaymentId = _PaymentId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Payment_Get_Data_G` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Payment_Get_Data_G`(
_ContractId VARCHAR(5)
)
BEGIN
	SELECT p.PaymentId AS 'ID', pt.TypeName AS 'Payment Type', p.PaymentDate AS 'Payment Date', 
		p.ReceiptNo AS 'Receipt #', p.PaymentAmount AS 'Amount', p.PaymentStatus AS 'Status', 
        p.Comment 
	FROM payments AS p INNER JOIN contracts AS c ON p.ContractId = c.ContractId 
		INNER JOIN payment_type AS pt ON p.PaymentTypeId = pt.TypeId 
	WHERE c.ContractId = _ContractId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Payment_New_Update` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Payment_New_Update`(
_PaymentId INT,
_ContractId INT,
_PaymentTypeId INT,
_PaymentDate DATE,
_ReceiptNo VARCHAR(50),
_PaymentAmount VARCHAR(100),
_PaymentStatus VARCHAR(20),
_Comment LONGTEXT
)
BEGIN
	IF _PaymentId = -1 THEN
		INSERT INTO payments(ContractId, PaymentTypeId, PaymentDate, ReceiptNo, PaymentAmount, PaymentStatus, Comment)
        VALUES (_ContractId, _PaymentTypeId, _PaymentDate, _ReceiptNo, _PaymentAmount, _PaymentStatus, _Comment);
    ELSE
		UPDATE payments
        SET PaymentTypeId = _PaymentTypeId,
			PaymentDate = _PaymentDate,
            ReceiptNo = _ReceiptNo,
            PaymentAmount = _PaymentAmount,
            PaymentStatus = _PaymentStatus,
            Comment = _Comment
        WHERE PaymentId = _PaymentId;
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Payment_Search_Data_G` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Payment_Search_Data_G`(
_SearchText VARCHAR(100),
_ContractId VARCHAR(5)
)
BEGIN
	SELECT p.PaymentId AS ID, pt.TypeName AS 'Payment Type', p.PaymentDate AS 'Payment Date', 
		p.ReceiptNo AS 'Receipt #', p.PaymentAmount AS 'Amount', p.PaymentStatus AS 'Status', 
        p.Comment 
        FROM payments AS p INNER JOIN contracts AS c ON p.ContractId = c.ContractId 
			INNER JOIN payment_type AS pt ON p.PaymentTypeId = pt.TypeId 
		WHERE (pt.TypeName LIKE CONCAT('%', _SearchText, '%') OR p.PaymentDate LIKE CONCAT('%', _SearchText, '%') OR 
			p.ReceiptNo LIKE CONCAT('%', _SearchText, '%') OR p.PaymentAmount LIKE CONCAT('%', _SearchText, '%') OR 
            p.PaymentStatus LIKE CONCAT('%', _SearchText, '%') OR p.Comment LIKE CONCAT('%', _SearchText, '%')) 
            AND c.ContractId = _ContractId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Tenant_CB_Data` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Tenant_CB_Data`()
BEGIN
	SELECT TenantId, CONCAT(TenantId, " - ", FirstName, " ", MiddleName, " ", LastName) AS 'Items' FROM tenants;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Tenant_CB_Data_N` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Tenant_CB_Data_N`()
BEGIN
	SELECT TenantId, CONCAT(TenantId, " - ", FirstName, " ", MiddleName, " ", LastName) AS 'Items' 
    FROM tenants;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Tenant_Get_Data_G` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Tenant_Get_Data_G`()
BEGIN
	SELECT TenantId AS ID, CONCAT(FirstName, " ", MiddleName, " ", LastName) AS 'Full Name', 
		MobileNo AS 'Mobile Number', EmailAddress AS 'Email Address', PermaAddress AS 'Permanent Address', 
        Company, AnnualIncome AS 'Annual Income', HouseholdNum AS 'Household Number' 
	FROM tenants;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Tenant_Get_Data_V` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Tenant_Get_Data_V`(
_PaymentId VARCHAR(5)
)
BEGIN
	SELECT p.PaymentId, pt.TypeName AS Items, p.PaymentDate, p.ReceiptNo, p.PaymentAmount, 
		p.PaymentStatus, p.Comment 
	FROM payments AS p INNER JOIN payment_type AS pt ON p.PaymentTypeId = pt.TypeId 
    WHERE p.PaymentId = _PaymentId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Tenant_New_Update` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Tenant_New_Update`(
_TenantId INT,
_FirstName VARCHAR(30),
_MiddleName VARCHAR(30),
_LastName VARCHAR(30),
_MobileNo VARCHAR(45),
_EmailAddress VARCHAR(45),
_PermaAddress VARCHAR(100),
_Company VARCHAR(75),
_AnnualIncome VARCHAR(100),
_HouseholdNum VARCHAR(10)
)
BEGIN
	IF _TenantId = -1 THEN
		INSERT INTO tenants(FirstName, MiddleName, LastName, MobileNo, 
            EmailAddress, PermaAddress, Company, AnnualIncome, HouseholdNum)
        VALUES (_FirstName, _MiddleName, _LastName, _MobileNo, 
            _EmailAddress, _PermaAddress, _Company, _AnnualIncome, _HouseholdNum);
    ELSE
		UPDATE tenants
        SET
			FirstName = _FirstName,
            MiddleName = _MiddleName,
            LastName = _LastName,
            MobileNo = _MobileNo,
            EmailAddress = _EmailAddress,
            PermaAddress = _PermaAddress,
            Company = _Company,
            AnnualIncome = _AnnualIncome,
            HouseholdNum = _HouseholdNum
        WHERE TenantId = _TenantId;
    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Tenant_Search_Data_G` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Tenant_Search_Data_G`(
_SearchText VARCHAR(100)
)
BEGIN
	SELECT TenantId AS ID, CONCAT(FirstName, " ", MiddleName, " ", LastName) AS 'Full Name', 
		MobileNo AS 'Mobile Number', EmailAddress AS 'Email Address', PermaAddress AS 'Permanent Address', 
        Company, AnnualIncome AS 'Annual Income', HouseholdNum AS 'Household Number'
	FROM tenants 
	WHERE CONCAT(FirstName, " ", MiddleName, " ", LastName) LIKE CONCAT('%', _SearchText, '%') OR
		MobileNo LIKE CONCAT('%', _SearchText, '%') OR EmailAddress LIKE CONCAT('%', _SearchText, '%') OR
        PermaAddress LIKE CONCAT('%', _SearchText, '%') OR Company LIKE CONCAT('%', _SearchText, '%') OR
        AnnualIncome LIKE CONCAT('%', _SearchText, '%') OR HouseholdNum LIKE CONCAT('%', _SearchText, '%');
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Unit_CB_Data` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Unit_CB_Data`()
BEGIN
	SELECT UnitId, CONCAT(UnitId, " - ", UnitType) AS 'Items' FROM units WHERE UnitStatus = 'vacant';
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Unit_CB_Data_N` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Unit_CB_Data_N`()
BEGIN
	SELECT UnitId, CONCAT(UnitId, " - ", UnitType) AS 'Items' 
    FROM units 
    WHERE UnitStatus = 'vacant';
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Unit_CB_Data_V` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Unit_CB_Data_V`(
_UnitType VARCHAR(50)
)
BEGIN
	SELECT UnitId, CONCAT(UnitId, " - ", UnitType) AS 'Item'
    FROM units 
    WHERE UnitStatus = 'vacant' OR UnitType = _UnitType;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Unit_Delete` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Unit_Delete`(
_UnitId INT
)
BEGIN
	DELETE FROM units WHERE UnitId = _UnitId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Unit_Expire` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Unit_Expire`(
_UnitId INT
)
BEGIN
	UPDATE units
    SET UnitStatus = 'unavailable'
    WHERE UnitId = _UnitId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Unit_Get_Data_G` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Unit_Get_Data_G`()
BEGIN
	SELECT UnitId AS 'ID', UnitType AS 'Type', UnitArea AS 'Area', 
		RentalAmount AS 'Rental Amount', TenantLimit AS 'Tenant Limit', 
		UnitStatus AS 'Unit Status' 
	FROM units;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Unit_Get_Data_V` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Unit_Get_Data_V`(
_UnitId VARCHAR(10)
)
BEGIN
	SELECT UnitId, UnitType, UnitArea, RentalAmount, TenantLimit, UnitStatus 
    FROM units 
    WHERE UnitId = _UnitId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Unit_New_Update` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Unit_New_Update`(
_UnitId INT,
_UnitType VARCHAR(15),
_UnitArea VARCHAR(50),
_RentalAmount VARCHAR(100),
_TenantLimit VARCHAR(10)
)
BEGIN
	IF _UnitId = -1 THEN
		INSERT INTO units(UnitType, UnitArea, RentalAmount, TenantLimit, UnitStatus)
        VALUES (_UnitType, _UnitArea, _RentalAmount, _TenantLimit, 'vacant');
	ELSE
		UPDATE units
        SET
            UnitType = _UnitType,
            UnitArea = _UnitArea,
            RentalAmount = _RentalAmount,
            TenantLimit = _TenantLimit
        WHERE UnitId = _UnitId;
	END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Unit_Search_Data_G` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Unit_Search_Data_G`(
_SearchText VARCHAR(100)
)
BEGIN
	SELECT UnitId AS 'ID', UnitType AS 'Type', UnitArea AS 'Area', RentalAmount AS 'Rental Amount', 
		TenantLimit AS 'Tenant Limit', UnitStatus AS 'Unit Status' 
	FROM units 
	WHERE UnitType LIKE CONCAT('%', _SearchText, '%') OR UnitArea LIKE CONCAT('%', _SearchText, '%') OR 
		RentalAmount LIKE CONCAT('%', _SearchText, '%') OR TenantLimit LIKE CONCAT('%', _SearchText, '%');
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-01-13 15:21:44
