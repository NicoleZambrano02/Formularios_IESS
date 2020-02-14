CREATE TABLE AUDITORIA
(id int identity (1,1) primary key not null,
ruc varchar(20)null,
razon_social varchar(20) null,
saldo_tributario numeric(5,2) null,
accion varchar(50) null)

CREATE TRIGGER INSERTAR_AUDITORIA
ON CONTRIBUYENTE
FOR INSERT
AS
INSERT INTO AUDITORIA(ruc, razon_social, accion)
SELECT INSERTED.RUC_Contr, inserted.RazonSocial_Contr, 'INSERCION' FROM INSERTED

DROP TRIGGER ACTUALIZAR_AUDITORIA

CREATE TRIGGER ACTUALIZAR_AUDITORIA
ON CONTRIBUYENTE
FOR UPDATE
AS
UPDATE AUDITORIA
SET ruc = inserted.RUC_Contr, razon_social = inserted.RazonSocial_Contr, saldo_tributario = inserted.SaldoTrib_Contr, accion = 'ACTUALIZACIÓN'
FROM AUDITORIA, INSERTED, DELETED 
WHERE AUDITORIA.ruc = DELETED.RUC_Contr
SELECT * FROM INSERTED // muestra registros de sala modificados

select * from AUDITORIA

DROP TRIGGER Auditoriap_Actual