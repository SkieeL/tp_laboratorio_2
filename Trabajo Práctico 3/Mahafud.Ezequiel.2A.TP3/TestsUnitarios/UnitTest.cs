using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Excepciones;

namespace TestsUnitarios
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void validaNacionalidadInvalidaException() {
            try {
                Alumno alumno = new Alumno(1, "Ezequiel", "Mahafud", "90000001", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            }
            catch (Exception e) {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }

        [TestMethod]
        public void validaDniInvalidoException() {
            try {
                Alumno alumno = new Alumno(1, "Ezequiel", "Mahafud", "-38999220", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            }
            catch (Exception e) {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }

            try {
                Alumno alumno = new Alumno(1, "Ezequiel", "Mahafud", "38999220", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                alumno.DNI = -1;
            }
            catch (Exception e) {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }

        [TestMethod]
        public void validaValorNumerico() {
            Alumno alumno = new Alumno(1, "Ezequiel", "Mahafud", "38999220", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            Assert.IsInstanceOfType(alumno.DNI, typeof(int));
        }

        [TestMethod]
        public void validaValoresNulos() {
            Universidad universidad = new Universidad();

            Assert.IsNotNull(universidad.Alumnos);
            Assert.IsNotNull(universidad.Instructores);
            Assert.IsNotNull(universidad.Jornadas);
        }
    }
}
