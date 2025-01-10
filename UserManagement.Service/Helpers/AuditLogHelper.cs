using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Data.Context;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Helpers
{
    internal class AuditLogHelper
    {
        private readonly AppDBContext _dbContext;

        public AuditLogHelper(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Logs an action to the AuditLog table.
        /// </summary>
        public async Task LogActionAsync(string action, string entityName, string entityId, string performedBy, string details = null)
        {
            var auditLog = new AuditLog
            {
                Action = action,
                EntityName = entityName,
                EntityId = entityId,
                PerformedBy = performedBy,
                Details = details
            };

            _dbContext.Add(auditLog);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves all audit logs.
        /// </summary>
        public async Task<List<AuditLog>> GetAllLogsAsync()
        {
            return await _dbContext.Set<AuditLog>().OrderByDescending(log => log.Timestamp).ToListAsync();
        }

        /// <summary>
        /// Retrieves audit logs filtered by entity name.
        /// </summary>
        public async Task<List<AuditLog>> GetLogsByEntityNameAsync(string entityName)
        {
            return await _dbContext.Set<AuditLog>()
                .Where(log => log.EntityName == entityName)
                .OrderByDescending(log => log.Timestamp)
                .ToListAsync();
        }

        /// <summary>
        /// Retrieves audit logs filtered by user who performed the action.
        /// </summary>
        public async Task<List<AuditLog>> GetLogsByUserAsync(string performedBy)
        {
            return await _dbContext.Set<AuditLog>()
                .Where(log => log.PerformedBy == performedBy)
                .OrderByDescending(log => log.Timestamp)
                .ToListAsync();
        }

        /// <summary>
        /// Retrieves audit logs for a specific entity (by ID).
        /// </summary>
        public async Task<List<AuditLog>> GetLogsByEntityIdAsync(string entityId)
        {
            return await _dbContext.Set<AuditLog>()
                .Where(log => log.EntityId == entityId)
                .OrderByDescending(log => log.Timestamp)
                .ToListAsync();
        }

        /// <summary>
        /// Retrieves audit logs filtered by a specific action.
        /// </summary>
        public async Task<List<AuditLog>> GetLogsByActionAsync(string action)
        {
            return await _dbContext.Set<AuditLog>()
                .Where(log => log.Action == action)
                .OrderByDescending(log => log.Timestamp)
                .ToListAsync();
        }

        /// <summary>
        /// Retrieves audit logs within a specific date range.
        /// </summary>
        public async Task<List<AuditLog>> GetLogsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbContext.Set<AuditLog>()
                .Where(log => log.Timestamp >= startDate && log.Timestamp <= endDate)
                .OrderByDescending(log => log.Timestamp)
                .ToListAsync();
        }
    }
}
