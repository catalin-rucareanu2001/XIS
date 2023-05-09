<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  
  <xsl:template match="/">
    <html>
      <head>
        <title>Serviciul 112</title>
      </head>
      <body>
        <h1>Serviciul 112</h1>
        <table border="2">
          <tr bgcolor="#fa5f5f">
            <th>Data apelului</th>
            <th>Ora apelului</th>
            <th>Dispecer</th>
            <th>Numele apelantului</th>
            <th>Prenumele apelantului</th>
            <th>Adresa apelului</th>
            <th>Descrierea apelului</th>
            <th>Ora interventiei</th>
            <th>Durata interventiei</th>
            <th>Echipa de interventie</th>
            <th>Activitatea desfasurata</th>
            <th>Coordonatorul de interventie</th>
          </tr>
          <xsl:for-each select="//serviciul_112/apeluri/apel">
            <tr>
              <td><xsl:value-of select="data"/></td>
              <td><xsl:value-of select="ora_apel"/></td>
              <td><xsl:value-of select="dispecer/@nume"/> <xsl:value-of select="dispecer/@prenume"/></td>
              <td><xsl:value-of select="nume_apelant"/></td>
              <td><xsl:value-of select="prenume_apelant"/></td>
              <td><xsl:value-of select="adresa"/></td>
              <td><xsl:value-of select="descriere"/></td>
              <td><xsl:value-of select="interventie/ora_interventie"/></td>
              <td><xsl:value-of select="interventie/durata"/> minute</td>
              <td><xsl:value-of select="interventie/echipa"/></td>
              <td><xsl:value-of select="interventie/activitate"/></td>
              <td><xsl:value-of select="interventie/coordonator/@nume"/> <xsl:value-of select="interventie/coordonator/@prenume"/></td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
  
</xsl:stylesheet>
