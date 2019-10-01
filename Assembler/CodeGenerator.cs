using System;
using System.Collections.Generic;
using System.Text;

namespace Assembler
{
    class CodeGenerator
    {
        private string GenerateF1(int opcode, int Ra, int Rb, int Rc)
        {
            //Conver Values to Binary and format 
            try
            {
                string opcodeBin = Convert.ToString(opcode, 2).PadLeft(5, '0');
                string RaBin = Convert.ToString(Ra, 2).PadLeft(3, '0');
                string RbBin = Convert.ToString(Rb, 2).PadLeft(3, '0');
                string RcBin = Convert.ToString(Rc, 2).PadLeft(3, '0');
                return $"{opcodeBin} {RaBin}{RbBin}{RcBin}";
            }catch(Exception e)
            {
                throw e;
            }
        }
        private string GenerateF2(int opcode, int Ra, int const_addrs)
        {
            //Conver Values to Binary and format
            try
            {
                string opcodeBin = Convert.ToString(opcode, 2).PadLeft(5, '0');
                string RaBin = Convert.ToString(Ra, 2).PadLeft(3, '0');
                string const_addrsBin = Convert.ToString(const_addrs, 2).PadLeft(8, '0');
                return $"{opcodeBin} {RaBin}{const_addrs}";
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }
        private string GenerateF3(int opcode, int const_addrs)
        {
            //Conver Values to Binary and format
            try{ 
                string opcodeBin = Convert.ToString(opcode, 2).PadLeft(5, '0');
                string const_addrsBin = Convert.ToString(const_addrs, 2).PadLeft(11, '0');
                return $"{opcodeBin} {const_addrs}";
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
