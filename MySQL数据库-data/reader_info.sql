-- MySQL dump 10.13  Distrib 8.0.35, for Win64 (x86_64)
--
-- Host: localhost    Database: data
-- ------------------------------------------------------
-- Server version	8.0.35

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `reader_info`
--

DROP TABLE IF EXISTS `reader_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reader_info` (
  `ReaderID` varchar(30) NOT NULL,
  `RTypeID` int DEFAULT NULL,
  `Rname` varchar(10) DEFAULT NULL,
  `sex` int DEFAULT NULL,
  `regist_date` date DEFAULT NULL,
  `valid_to` date DEFAULT NULL,
  `Contact` varchar(20) DEFAULT NULL,
  `hold_count` int DEFAULT NULL,
  `borrow_count` int DEFAULT NULL,
  `break_time` int DEFAULT NULL,
  `state` int DEFAULT NULL,
  `Remark` text,
  `password` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ReaderID`),
  KEY `FK_Reference_2` (`RTypeID`),
  CONSTRAINT `FK_Reference_2` FOREIGN KEY (`RTypeID`) REFERENCES `readertype` (`RTypeID`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reader_info`
--

LOCK TABLES `reader_info` WRITE;
/*!40000 ALTER TABLE `reader_info` DISABLE KEYS */;
INSERT INTO `reader_info` VALUES ('20210902150601',1,'jack',0,'2021-09-01','2025-09-01','12345678999',2,9,0,0,'fine ，wuhu','123456'),('202312282255322b87b762-c7e3-4',2,'帅气一哥们',0,'2023-12-28','2025-10-10','101010101010',2,2,0,0,'很好','8888'),('20231229170631531d4217-696a-4',1,'华作',0,'2023-12-29','2025-01-01','98765432188',1,1,0,0,'好得很','321going'),('202312291720082fedb5bd-31f6-4',2,'王老师',1,'2023-12-29','2026-10-09','8908080',1,1,0,0,'remarking','567'),('20231229173306a1332304-b918-4',1,'阿百',0,'2023-12-29','2026-10-10','1234567999',1,1,0,0,'好','7890');
/*!40000 ALTER TABLE `reader_info` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-01-25 21:47:38
