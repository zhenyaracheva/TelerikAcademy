<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:template match="/">
        <html>
            <body>
                <h1>Students</h1>
                <table bgcolor="#E0E0E0" cellspacing="1">
                    <tr bgcolor="#EEEEEE">
                        <th>Student</th>
                        <th>Gender</th>
                        <th>Birth Date</th>
                        <th>Phone</th>
                        <th>E-mail</th>
                        <th>Course</th>
                        <th>Specialty</th>
                        <th>Faculty #</th>
                        <th>Exams</th>
                    </tr>
                    <xsl:for-each select="students/student">
                        <tr bgcolor="white">
                            <td>
                                <xsl:value-of select="name"/>
                            </td>
                            <td>
                                <xsl:value-of select="sex"/>
                            </td>
                            <td>
                                <xsl:value-of select="birthdate"/>
                            </td>
                            <td>
                                <xsl:value-of select="phone"/>
                            </td>
                            <td>
                                <xsl:value-of select="email"/>
                            </td>
                            <td>
                                <xsl:value-of select="course"/>
                            </td>
                            <td>
                                <xsl:value-of select="speciality"/>
                            </td>
                            <td>
                                <xsl:value-of select="facultyNumber"/>
                            </td>
                            <td>
                                <ul>
                                    <xsl:for-each select="exams/exam">
                                        <li>
                                            <span>Name: <xsl:value-of select="name"/>:</span>
                                        </li>
                                        <xsl:for-each select="tutor">
                                            <div>Tutor Name: <xsl:value-of select="name"/></div>
                                            <div>Tutor Certification:  <xsl:value-of select="certification"/></div>
                                        </xsl:for-each>
                                        <xsl:for-each select="enrollment">
                                            <div>Enrollment Date: <xsl:value-of select="date"/></div>
                                            <div>Enrollment Score: <xsl:value-of select="examScore"/></div>
                                        </xsl:for-each>
                                        <div>Score: <xsl:value-of select="score"/></div>
                                    </xsl:for-each>

                                </ul>
                            </td>
                        </tr>
                    </xsl:for-each>
                </table>
            </body>
        </html>
    </xsl:template>
</xsl:stylesheet>