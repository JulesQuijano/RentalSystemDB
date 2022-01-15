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
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contracts`
--

LOCK TABLES `contracts` WRITE;
/*!40000 ALTER TABLE `contracts` DISABLE KEYS */;
INSERT INTO `contracts` VALUES (1,1,1,'2019-01-15','2021-01-14',0,'Consistent Payment!'),(2,2,2,'2018-02-14','2022-02-14',1,'Missing Payment'),(3,3,2,'2022-01-01','2022-01-08',1,'test'),(4,4,4,'2022-01-08','2022-01-15',1,'test2'),(5,1,2,'2022-01-09','2022-01-13',1,''),(6,7,3,'2022-01-09','2022-01-10',1,''),(7,6,2,'2022-01-09','2022-01-09',0,''),(8,5,2,'2022-01-09','2022-01-09',0,''),(9,4,2,'2022-01-09','2022-01-09',0,''),(10,3,2,'2022-01-09','2022-01-09',0,''),(11,7,2,'2022-01-09','2022-01-09',0,''),(12,5,3,'2022-01-11','2022-01-12',0,''),(13,5,3,'2022-01-11','2022-01-12',0,''),(14,1,4,'2022-01-11','2022-01-13',0,''),(15,6,2,'2022-01-13','2022-01-14',0,''),(16,6,3,'2022-01-13','2022-01-14',0,'');
/*!40000 ALTER TABLE `contracts` ENABLE KEYS */;
UNLOCK TABLES;

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
-- Dumping data for table `payment_type`
--

LOCK TABLES `payment_type` WRITE;
/*!40000 ALTER TABLE `payment_type` DISABLE KEYS */;
INSERT INTO `payment_type` VALUES (1,'Rental Fee'),(2,'Electric Bill'),(3,'Water Bill'),(4,'Miscellaneous Fee'),(5,'Initial Payment');
/*!40000 ALTER TABLE `payment_type` ENABLE KEYS */;
UNLOCK TABLES;

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
  `ReceiptNo` varchar(20) DEFAULT NULL,
  `PaymentAmount` decimal(12,2) DEFAULT NULL,
  `PaymentStatus` varchar(20) DEFAULT NULL,
  `Comment` longtext,
  PRIMARY KEY (`PaymentId`),
  UNIQUE KEY `UNQ_Payment_Contract` (`PaymentId`,`ContractId`),
  KEY `ContractId` (`ContractId`),
  KEY `fk_paymentType` (`PaymentTypeId`),
  CONSTRAINT `fk_paymentType` FOREIGN KEY (`PaymentTypeId`) REFERENCES `payment_type` (`TypeId`),
  CONSTRAINT `payments_ibfk_1` FOREIGN KEY (`ContractId`) REFERENCES `contracts` (`ContractId`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payments`
--

LOCK TABLES `payments` WRITE;
/*!40000 ALTER TABLE `payments` DISABLE KEYS */;
INSERT INTO `payments` VALUES (1,1,1,'2020-11-23','09823',2000.50,'Unpaid','yes'),(2,1,5,'2020-11-23','0124',500.00,'Paid','maybe'),(3,2,3,'2021-06-18','0125',400.00,'Paid','so'),(4,2,1,'2021-06-18','0126',300.00,'Paid','no'),(6,3,1,'2022-01-08','1',1.00,'Paid','1'),(7,3,2,'2022-01-01','4',23.00,'Unpaid','23'),(8,4,3,'2022-01-08','12344',3213.00,'Paid','ergterwgewge'),(10,7,5,'2022-01-09','0987',1234.00,'Paid',''),(11,8,5,'2022-01-09','8486',0.00,'Paid',''),(12,9,5,'2022-01-09','',0.00,'Paid',''),(13,10,5,'2022-01-09','25464',23442.00,'Paid',''),(14,11,5,'2022-01-09','',0.00,'Paid',''),(15,12,5,'2022-01-11','643523',1445.00,'Paid',''),(16,14,5,'2022-01-11','',0.00,'Paid',''),(17,15,5,'2022-01-14','1234678',64675.00,'Paid',''),(18,16,5,'2022-01-13','3456',6546.00,'Paid','');
/*!40000 ALTER TABLE `payments` ENABLE KEYS */;
UNLOCK TABLES;

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
  `AnnualIncome` decimal(12,2) DEFAULT NULL,
  `HouseholdNum` int DEFAULT NULL,
  PRIMARY KEY (`TenantId`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tenants`
--

LOCK TABLES `tenants` WRITE;
/*!40000 ALTER TABLE `tenants` DISABLE KEYS */;
INSERT INTO `tenants` VALUES (1,'Madeline','Bertha','syk','4619-124-6666','msykes@gmail.com','Suspendisse ac metus','Eu Tellus Corpporation',11000.00,3),(2,'Drake','Morgan','Bruce','7122-301-6076','d_bruce6027@google.com','magnis dis parturient montes,','Nulla Ante Iaculis Industries',1500.50,5),(3,'Len','Yolanda','Sharpe','1444-889-8405','s.len@google.com','ipsum sodales purus, in','Proin Foundation',18955.00,3),(4,'Jerome','Rama','Brock','8129-382-3013','b_jerome@google.com','In faucibus. Morbi vehicula.','Imperdiet Ullamcorper Duis Corp.',25998.00,2),(5,'TEA','Moana','Nunez','3458-021-7320','t_nunez3933@google.com','parturient montes, nascetur ridiculus','Ante Dictum Mi Corporation',19075.00,4),(6,'asdf','asdfsf','asdfq','1235467','dgbsssssssdf','dfdsvb','sdfgdsv',166164.00,3),(7,'rhgjjs','fdgjkjtr','hgsfjs','2356','gdfshjjhy','gfhdhsdm','lk;hfjghj',23567.00,4);
/*!40000 ALTER TABLE `tenants` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `units`
--

DROP TABLE IF EXISTS `units`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `units` (
  `UnitId` int NOT NULL AUTO_INCREMENT,
  `UnitType` varchar(30) DEFAULT NULL,
  `UnitArea` decimal(12,2) DEFAULT NULL,
  `RentalAmount` decimal(12,2) DEFAULT NULL,
  `TenantLimit` int DEFAULT NULL,
  `UnitStatus` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`UnitId`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `units`
--

LOCK TABLES `units` WRITE;
/*!40000 ALTER TABLE `units` DISABLE KEYS */;
INSERT INTO `units` VALUES (1,'Single Detached',17.00,14822.00,3,'occupied'),(2,'Duplex',16.00,13199.00,2,'occupied'),(3,'Duplex',15.00,11358.00,2,'occupied'),(4,'Bungalow',18.00,11234.00,1,'occupied'),(5,'Condo',16.00,11450.00,2,'vacant'),(6,'Town House',17.00,12175.00,2,'vacant'),(7,'Bungalow',19.00,12089.00,2,'vacant'),(8,'Single Detached',18.00,10989.00,2,'vacant'),(9,'Town House',15.00,14418.00,2,'vacant'),(10,'Condo',20.00,10132.00,3,'vacant'),(16,'Bungalow',12.30,20.50,4,'vacant');
/*!40000 ALTER TABLE `units` ENABLE KEYS */;
UNLOCK TABLES;

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
_ReceiptNo VARCHAR(20),
_PaymentAmount DECIMAL(12,2),
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
_AnnualIncome DECIMAL(12, 2),
_HouseholdNum INT
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
_UnitArea DECIMAL(12, 2),
_RentalAmount DECIMAL(12, 2),
_TenantLimit INT
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

-- Dump completed on 2022-01-15 20:23:59
