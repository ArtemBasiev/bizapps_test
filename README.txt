


     SQL ������� ��� 2 ������� ��������� � ����� 'task �2'

     ��� ��������� ����� ��������� � 3 �������.

     ��� �������� �������� FireBird, ������������ � 3 �������:


*************************************************************************************************************************************************************
       ��������� ������� ��������� ��� ������:
***********************************************************************************************************************************************************
               create or alter procedure SEL_KATEGORY
               returns (
                 KAT varchar(30) character set UNICODE_FSS)
               AS
              begin

                 /*������ ������� ���� ��������� � ������� �����*/
                 for select a.name_kat
                 from KATEGORY a
                 into  :KAT do
                   begin
                    suspend;
                   end
              end


**************************************************************************************************************************************************
      ��������� �������� ��������� �� ������������:
*****************************************************************************************************************************************************8
    create or alter procedure CREATE_KATEGORY (
        NAME_KAT varchar(30) character set UNICODE_FSS)
     returns (
          INF_MES varchar(30) character set UNICODE_FSS,
          FLAG integer)
     AS
     declare  com_id_kat int;

     begin

         /*������� ID ��������� �� ��������� ����� ���������*/
         com_id_kat = null;
         select a.id_kat
         from kategory a
         where  a.name_kat = :name_kat
         into:com_id_kat ;
         
        /*��������� �������� ��� ��������� �� ������ ��������*/
       if(upper(name_kat) !='' )
       then
       begin
               /*��������� ID �������� ��������� �� ������� ��������*/
              if (com_id_kat is null) then
                  begin
                  /*������� ��������� �� �������� ���������� ��������� � �������� ����� ��� ��������� ����� ���������*/
                      inf_mes='��������� ������� ���������';
                      flag=1;
                      suspend;
                  end
              else
                   begin
                   /*������� ��������� � ���, ��� ��������� ������������� ��������� ��� ���������� � �������� ����� ��� ��������� ����� ���������*/
                      inf_mes='��������� ��� ����������';
                      flag=0;
                      suspend;
                   end
       end
       else 
       begin
          /*������� ��������� � ������������� ����� ������������ ���������  � �������� ����� ��� ��������� ����� ���������*/
       inf_mes='������� ������������ ���������';
       flag=0;
       suspend;
       end

   end