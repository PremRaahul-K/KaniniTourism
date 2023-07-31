using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using UserAPI.Interfaces;
using UserAPI.Models;
using UserAPI.Models.Context;

namespace UserAPI.Services
{
    public class UserRepo : IRepo<int, User>
    {
        private readonly UserContext _context;

        public UserRepo(UserContext context)
        {
            _context = context;
        }
        public async Task<User?> Add(User item)
        {
            if (_context.Users!=null&&_context.UserDetails!=null&_context.Travellers!=null&&_context.TravelAgents!=null)
            {
                await _context.Users.AddAsync(item);
                await _context.SaveChangesAsync();
                return item;
            }
            return null;
        }

        public async Task<User?> Delete(User item)
        {
            var user = await Get(item.Id);
            if (_context.Users != null && _context.UserDetails != null && _context.TravelAgents != null && _context.Travellers != null)
            {
                if (user != null)
                {
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();
                    return user;
                }
            }
            return null;
        }

        public async Task<User?> Get(int key)
        {
            if (_context.Users != null && _context.UserDetails != null && _context.TravelAgents != null && _context.Travellers != null)
            {
                return await _context.Users.Include(u => u.UserDetail).ThenInclude(ud => ud.Traveller).Include(u => u.UserDetail).ThenInclude(us => us.TravelAgent).FirstOrDefaultAsync(u => u.Id == key);
            }
            return null;
        }

        public async Task<List<User>?> GetAll()
        {
            if (_context.Users != null && _context.UserDetails != null && _context.TravelAgents != null && _context.Travellers != null)
            {
                return await _context.Users.Include(u => u.UserDetail).ThenInclude(us => us.Traveller).Include(u => u.UserDetail).ThenInclude(us => us.TravelAgent).ToListAsync();
            }
            return null;
        }

        public async Task<User?> Update(User item)
        {
            if (_context.Users != null && _context.UserDetails != null && _context.TravelAgents != null && _context.Travellers != null)
            {
                _context.Users.Update(item);
                await _context.SaveChangesAsync();
                return item;
            }
            return null;
        }
    }
}
