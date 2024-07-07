// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

// using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;
using Npgsql;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace Microsoft.EntityFrameworkCore;

public class RetryingSqlServerRetryingExecutionStrategy(ExecutionStrategyDependencies dependencies) : NpgsqlRetryingExecutionStrategy(dependencies)
{
    // protected override bool ShouldRetryOn(Exception exception)
    // {
    //     if (exception is SqlException sqlException)
    //     {
    //         foreach (SqlError error in sqlException.Errors)
    //         {
    //             // EF Core issue logged to consider making this a default https://github.com/dotnet/efcore/issues/33191
    //             if (error.Number is 4060)
    //             {
    //                 // Don't retry on login failures associated with default database not existing due to EF migrations not running yet
    //                 return false;
    //             }
    //             // Workaround for https://github.com/dotnet/aspire/issues/1023
    //             else if (error.Number is 0 || (error.Number is 203 && sqlException.InnerException is Win32Exception))
    //             {
    //                 return true;
    //             }
    //         }
    //     }
    //
    //     return base.ShouldRetryOn(exception);
    // }
    
    protected override bool ShouldRetryOn(Exception? exception)
    {
        if (exception is PostgresException postgresException)
        {
            // PostgreSQL-specific error codes
            switch (postgresException.SqlState)
            {
                // Login failures associated with default database not existing due to EF migrations not running yet
                case "3D000": // invalid_catalog_name
                    return false;
                
                // Equivalent to error.Number 0 or 203 in SQL Server
                case "08000": // connection_exception
                case "08003": // connection_does_not_exist
                case "08006": // connection_failure
                case "08001": // sqlclient_unable_to_establish_sqlconnection
                case "08004": // sqlserver_rejected_establishment_of_sqlconnection
                case "08007": // transaction_resolution_unknown
                    return true;
            }
        }
    
        return base.ShouldRetryOn(exception);
    }
}
