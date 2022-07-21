Imports System.Web.Mvc
Imports System.Data.Entity

Namespace Controllers
    Public Class DepartmentController
        Inherits Controller

        Dim db As TestingCompanyEntities = New TestingCompanyEntities()
        Function Index() As ActionResult

            Return View()
        End Function


        <HttpGet()>
        Function GetData(start As Integer, length As Integer) As JsonResult
            Dim search = HttpContext.Request.QueryString("search[value]")

            Dim query = db.Departments.Where(Function(c) c.Name.Contains(search)).OrderBy(Function(c) c.Name).Skip(start).Take(length).ToList()
            Dim count = db.Departments.Count()

            Return Json(New With {.data = query, .recordsFiltered = count, .recordsTotal = count}, JsonRequestBehavior.AllowGet)
        End Function


        Function Create() As ActionResult
            Return PartialView()

        End Function
        <HttpPost()>
        Function Create(Department As Department) As ActionResult

            If Not ModelState.IsValid Then
                Throw New HttpException(400, "The Data is not valid")
            End If

            db.Departments.Add(Department)
            db.SaveChanges()
            Return Json(New With {Department.Name, Department.ID})

        End Function

        Function Edit(id As Integer) As ActionResult
            Dim department = db.Departments.Find(id)

            Return PartialView(department)
        End Function

        <HttpPost()>
        Function Edit(Department As Department) As ActionResult
            db.Entry(Department).State = EntityState.Modified
            db.SaveChanges()
            Return Json(New With {Department.Name, Department.ID})
        End Function


        Function Delete(id As Integer) As ActionResult
            Dim department = db.Departments.Find(id)
            Return View(department)
        End Function

        <HttpPost()>
        Function DeleteConfirmed(id As Integer) As ActionResult
            Dim department = db.Departments.Find(id)
            db.Departments.Remove(department)
            db.SaveChanges()
            Return Json("Success")
        End Function


    End Class
End Namespace