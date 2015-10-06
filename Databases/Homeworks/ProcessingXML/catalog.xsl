<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:template match="/">
        <html>
            <body>
                <h1>Catalog</h1>
                <table border="1">
                    <tr bgcolor="#9acd32">
                        <td>Album Name</td>
                        <td>Artist</td>
                        <td>Year</td>
                        <td>Producer</td>
                        <td>Price</td>
                        <td>Songs</td>
                    </tr>
                    <xsl:for-each select="catalog/album">
                        <tr>
                            <td><xsl:value-of select="name"/></td>
                            <td><xsl:value-of select="artist"/></td>
                            <td><xsl:value-of select="year"/></td>
                            <td><xsl:value-of select="producer"/></td>
                            <td><xsl:value-of select="price"/></td>
                            <td>
                                <ul>
                                    <xsl:for-each select="songs/song">
                                    <li><xsl:value-of select="title"/></li>
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