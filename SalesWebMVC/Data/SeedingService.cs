using SalesWebMVC.Models;
using System.Linq;
using SalesWebMVC.Models.Enums;
using System;

namespace SalesWebMVC.Data
{
    public class SeedingService
    {
        private SalesWebMVCContext _context;

        /*Quando o SeedingService for criado, ele receberá uma instancia do context
        */
        public SeedingService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() ||
                _context.Seller.Any() ||
                _context.SalesRecord.Any())
            {
                return; // DB has seeded(o banco já foi populado)
            }

            Department d1 = new Department(1, "Informática");
            Department d2 = new Department(2, "Eletrônicos");
            Department d3 = new Department(3, "Books");
            Department d4 = new Department(4, "Vesturário");

            Seller s1 = new Seller(1, "Keziah Maciel Lopes", "keziahmaciel@gmail.com", new DateTime(1980, 10, 28), 4000.00, d2);
            Seller s2 = new Seller(2, "Dione Regis Maciel", "dionerm86@gmail.com", new DateTime(1986, 5, 6), 4000.00, d1);
            Seller s3 = new Seller(3, "Otávio Lopes Maciel", "otaviolopes@gmail.com", new DateTime(2017, 5, 17), 4000.00, d3);
            Seller s4 = new Seller(4, "Marcela Lopes Maciel", "marcelalopes@gmail.com", new DateTime(2018, 5, 6), 4000.00, d4);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2018, 09, 25), 11000.0, SalesStatus.Faturado, s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2018, 09, 4), 7000.0, SalesStatus.Faturado, s3);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2018, 09, 13), 4000.0, SalesStatus.Cancelado, s4);
            SalesRecord r4 = new SalesRecord(4, new DateTime(2018, 09, 1), 8000.0, SalesStatus.Faturado, s1);
            SalesRecord r5 = new SalesRecord(5, new DateTime(2018, 09, 21), 3000.0, SalesStatus.Faturado, s3);
            SalesRecord r6 = new SalesRecord(6, new DateTime(2018, 09, 15), 2000.0, SalesStatus.Faturado, s1);
            SalesRecord r7 = new SalesRecord(7, new DateTime(2018, 09, 28), 13000.0, SalesStatus.Faturado, s2);
            SalesRecord r8 = new SalesRecord(8, new DateTime(2018, 09, 11), 4000.0, SalesStatus.Faturado, s4);
            SalesRecord r9 = new SalesRecord(9, new DateTime(2018, 09, 14), 11000.0, SalesStatus.Pendente, s2);
            SalesRecord r10 = new SalesRecord(10, new DateTime(2018, 09, 7), 9000.0, SalesStatus.Faturado, s2);
            SalesRecord r11 = new SalesRecord(11, new DateTime(2018, 09, 13), 6000.0, SalesStatus.Faturado, s2);
            SalesRecord r12 = new SalesRecord(12, new DateTime(2018, 09, 25), 7000.0, SalesStatus.Pendente, s3);
            SalesRecord r13 = new SalesRecord(13, new DateTime(2018, 09, 29), 10000.0, SalesStatus.Faturado, s4);
            SalesRecord r14 = new SalesRecord(14, new DateTime(2018, 09, 4), 3000.0, SalesStatus.Faturado, s3);
            SalesRecord r15 = new SalesRecord(15, new DateTime(2018, 09, 12), 4000.0, SalesStatus.Faturado, s1);
            SalesRecord r16 = new SalesRecord(16, new DateTime(2018, 10, 5), 2000.0, SalesStatus.Faturado, s4);
            SalesRecord r17 = new SalesRecord(17, new DateTime(2018, 10, 1), 12000.0, SalesStatus.Faturado, s1);
            SalesRecord r18 = new SalesRecord(18, new DateTime(2018, 10, 24), 6000.0, SalesStatus.Faturado, s3);
            SalesRecord r19 = new SalesRecord(19, new DateTime(2018, 10, 22), 8000.0, SalesStatus.Faturado, s3);
            SalesRecord r20 = new SalesRecord(20, new DateTime(2018, 10, 15), 8000.0, SalesStatus.Faturado, s2);
            SalesRecord r21 = new SalesRecord(21, new DateTime(2018, 10, 17), 9000.0, SalesStatus.Faturado, s2);
            SalesRecord r22 = new SalesRecord(22, new DateTime(2018, 10, 24), 4000.0, SalesStatus.Faturado, s4);
            SalesRecord r23 = new SalesRecord(23, new DateTime(2018, 10, 19), 11000.0, SalesStatus.Cancelado, s2);
            SalesRecord r24 = new SalesRecord(24, new DateTime(2018, 10, 12), 8000.0, SalesStatus.Faturado, s3);
            SalesRecord r25 = new SalesRecord(25, new DateTime(2018, 10, 31), 7000.0, SalesStatus.Faturado, s3);
            SalesRecord r26 = new SalesRecord(26, new DateTime(2018, 10, 6), 5000.0, SalesStatus.Faturado, s4);
            SalesRecord r27 = new SalesRecord(27, new DateTime(2018, 10, 13), 9000.0, SalesStatus.Pendente, s1);
            SalesRecord r28 = new SalesRecord(28, new DateTime(2018, 10, 7), 4000.0, SalesStatus.Faturado, s3);
            SalesRecord r29 = new SalesRecord(29, new DateTime(2018, 10, 23), 12000.0, SalesStatus.Faturado, s3);
            SalesRecord r30 = new SalesRecord(30, new DateTime(2018, 10, 12), 5000.0, SalesStatus.Faturado, s2);

            _context.Department.AddRange(d1, d2, d3, d4);

            _context.Seller.AddRange(s1, s2, s3, s4);

            _context.SalesRecord.AddRange(
                r1, r2, r3, r4, r5, r6, r7, r8, r9, r10,
                r11, r12, r13, r14, r15, r16, r17, r18, r19, r20,
                r21, r22, r23, r24, r25, r26, r27, r28, r29, r30
            );

            _context.SaveChanges();
        }
    }
}
